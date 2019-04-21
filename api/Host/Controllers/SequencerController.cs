using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sequences;
using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Repository;
using Timeseries.Api.Services;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequencerController : ControllerBase
    {
        private readonly IRecordingStackMachine _stackmachine;
        private readonly IRepository<IDocument> _repository;
        private readonly IMemoryCache _memoryCache;

        public SequencerController(IRepository<IDocument> repository, IMemoryCache memoryCache, IRecordingStackMachine stackmachine)
        {
            _repository = repository;
            _stackmachine = stackmachine;
            _memoryCache= memoryCache;
        }

        /// <summary>
        /// Get a list of the named sequences.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Names")]
        public IActionResult GetNames()
        {
            var items = SequenceFactory.List().Concat(_repository.List().Select(a=>a.Key));
            return new JsonResult(items);
        }

        /// <summary>
        /// Get a list of commands known to the sequencer engine.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Commands")]
        public IActionResult GetCommands()
        {
            var items = _stackmachine.Commands;
            return new JsonResult(items);
        }

        /// <summary>
        /// Get an array of values from the sequencer engine.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Preview")]
        public IActionResult Get()
        {
            return _stackmachine.Context.HasA<IEnumerable<double>>()
                ? new JsonResult(((IEnumerable<double>)_stackmachine.Context.Peek()).Take(Magic.DEFAULT_PREVIEW_COUNT))
                : (IActionResult)NoContent();
        }

        /// <summary>
        /// Evaluate the sequencer engine commands.
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        // POST: api/Sequence
        [HttpPost("Eval")]
        public IActionResult Post([FromBody]string[] commands)
        {
            foreach (var command in commands.Select(a => a.ToLower()))
            {
                switch (command)
                {
                    case "reset":
                        _stackmachine.History.Add(command);
                        _stackmachine.Reset();
                        break;
                    case "save":
                        _stackmachine.History.Add(command);
                        if (_stackmachine.Context.HasA<string>())
                        {
                            var key = _stackmachine.Context.Pop<string>();
                            var doc = new Doc { Key = key, Value = _stackmachine.History };
                            _repository.Create(doc);
                        }
                        break;
                    case "load":
                        _stackmachine.History.Add(command);
                        if (_stackmachine.Context.HasA<string>())
                        {
                            var key = _stackmachine.Context.Pop<string>();
                            var doc = _repository.Read(key);
                            if (doc != null)
                            {
                                var text = ((object[])doc.Value).Cast<string>();

                                _stackmachine.Reset();
                                _stackmachine.Eval(text);
                            }
                            else if (SequenceFactory.List().Contains(key))
                            {
                                var seq = SequenceFactory.Load(key);
                                _stackmachine.Context.Push(seq);
                            }
                        }
                        break;
                    case "delete":
                        _stackmachine.History.Add(command);
                        if (_stackmachine.Context.HasA<string>())
                        {
                            var key = _stackmachine.Context.Pop<string>();
                            var doc = _repository.Read(key);
                            if (doc != null)
                            {
                                _repository.Delete(doc._id);
                            }
                        }
                        break;
                    default:
                        _stackmachine.Eval(command);
                        break;
                }
            }

            return new JsonResult(_stackmachine.Context.ToDisplay());
        }
    }
}
