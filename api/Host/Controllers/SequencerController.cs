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
        private readonly IMemoryCache _memoryCache;
        private readonly IRepository<object> _repository;

        private Lazy<IStackMachine> _sequencer;

        public SequencerController( IMemoryCache memoryCache)
        {
            _sequencer = new Lazy<IStackMachine>(() => (IStackMachine)memoryCache.GetOrCreate(Magic.SEQUENCE_BUILDER_KEY, entry => entry.Value = new StackMachine(typeof(SequenceCommands), typeof(RepositoryCommands))));
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
        [HttpGet("commands")]
        public IActionResult GetCommands()
        {
            var items = _sequencer.Value.Commands;
            return new JsonResult(items);
        }

        /// <summary>
        /// Get an array of values from the sequencer engine.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var seq = _sequencer.Value.Context.Peek() as IEnumerable<double>;

            return seq != null
                ? (IActionResult)new JsonResult(seq.Take(Magic.DEFAULT_PREVIEW_COUNT))
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
            _sequencer.Value.Eval(commands);

            return new JsonResult(_sequencer.Value.Context.ToDisplay());
        }
    }
}
