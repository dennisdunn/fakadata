using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sequences;
using SimpleStackMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Models;
using Timeseries.Api.Repository;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequencerController : ControllerBase
    {
        Lazy<StackMachine> SequenceBuilder { get;set;}

        public SequencerController(IMemoryCache memoryCache)
        {
            SequenceBuilder = new Lazy<StackMachine>(()=> (StackMachine)memoryCache.GetOrCreate(Magic.SEQUENCE_BUILDER_KEY, entry => entry.Value = new StackMachine(typeof(SequenceCommands))));
        }

        [HttpGet("Names")]
        public IActionResult GetNames()
        {
            var items = SequenceFactory.List();
            return new JsonResult(items);
        }

        [HttpGet("Commands")]
        public IActionResult GetCommands()
        {
            var items = SequenceBuilder.Value.Commands;
            return new JsonResult(items);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var seq = SequenceBuilder.Value.Context.Peek() as IEnumerable<double>;

            return seq != null
                ? (IActionResult)new JsonResult(seq.Take(Magic.DEFAULT_PREVIEW_COUNT))
                : (IActionResult)NoContent();
        }

        // POST: api/Sequence
        [HttpPost]
        public IActionResult Post([FromBody]string[] commands)
        {
            SequenceBuilder.Value.Eval(commands);

            return new JsonResult(SequenceBuilder.Value.Context.ToDisplay());
        }
    }
}
