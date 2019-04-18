using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Timeseries.Api.Models;
using Timeseries.Api.Repository;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequenceController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var list = Sequences.SequenceFactory.List();
            return new JsonResult(list);
        }

        // POST: api/Sequence
        [HttpPost]
        public IActionResult Post([FromBody]string[] text)
        {
            var builder = new Sequences.Builder();
            builder.Eval(text);

            var seq = builder.Build().Take(100);
            return new JsonResult(seq);
        }
    }
}
