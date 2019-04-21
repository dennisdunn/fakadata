using EmbeddedSequences;
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

        public SequencerController(IRepository<IDocument> repository, IRecordingStackMachine stackmachine)
        {
            _repository = repository;
            _stackmachine = stackmachine;
        }

        /// <summary>
        /// Get a list of the named sequences.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Names")]
        public IActionResult GetNames()
        {
            var items = SequenceFactory.List();
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
        [HttpGet]
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
            _stackmachine.Eval(commands);

            return new JsonResult(_stackmachine.Context.ToDisplay());
        }
    }
}
