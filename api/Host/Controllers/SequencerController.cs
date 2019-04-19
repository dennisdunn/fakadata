using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sequences;
using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Repository;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequencerController : ControllerBase
    {
        private readonly IRepository<object> _repository;

        Lazy<StackMachine> SequencerEngine { get; set; }

        public SequencerController(IRepository<object> repository, IMemoryCache memoryCache)
        {
            SequencerEngine = new Lazy<StackMachine>(() => (StackMachine)memoryCache.GetOrCreate(Magic.SEQUENCE_BUILDER_KEY, entry => entry.Value = new StackMachine(typeof(SequenceCommands))));

            _repository = repository;
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
        /// Get a list of operations known to the sequencer engine.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Operations")]
        public IActionResult GetOperations()
        {
            var items = SequencerEngine.Value.Commands;
            return new JsonResult(items);
        }

        /// <summary>
        /// Get an array of values from the sequencer engine.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var seq = SequencerEngine.Value.Context.Peek() as IEnumerable<double>;

            return seq != null
                ? (IActionResult)new JsonResult(seq.Take(Magic.DEFAULT_PREVIEW_COUNT))
                : (IActionResult)NoContent();
        }

        /// <summary>
        /// Evaluate the sequencer engine operations.
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        // POST: api/Sequence
        [HttpPost("Eval")]
        public IActionResult PostEval([FromBody]string[] operations)
        {
            SequencerEngine.Value.Eval(operations);

            return new JsonResult(SequencerEngine.Value.Context.ToDisplay());
        }

        /// <summary>
        /// Save the list of sequencer engine operations with the given name.
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        // POST: api/Sequence/key
        [HttpPost("{key}")]
        public IActionResult Post(string key, [FromBody]string[] operations)
        {
            return Ok();
        }

        /// <summary>
        /// Delete the named sequencer.
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        // DELETE: api/Sequence/key
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            return Ok();
        }
    }
}
