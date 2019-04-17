using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Models;
using Timeseries.Api.Repository;
using Timeseries.Api.Signals;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequenceController : ControllerBase
    {
        private readonly IRepository<Signal> _repository;

        public SequenceController(IRepository<Signal> repository)
        {
            _repository = repository;
        }

        // POST: api/Sequence
        [HttpPost]
        public JsonResult Post([FromBody]string[] text)
        {
            var builder = new Sequences.Builder();
            builder.Eval(text);

            var seq = builder.Build().Take(100);
            return new JsonResult(seq);
        }
    }
}
