using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using Timeseries.Api.Evaluator;
using Timeseries.Api.Models;
using Timeseries.Api.Repository;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        const int DEFAULT_PREVIEW_COUNT = 100;
        private readonly IDefinitionRepository _repository;

        public PreviewController(IDefinitionRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Preview/source
        [HttpGet]
        public IActionResult Get([FromQuery]List<string> source)
        {
            if (source.Count == 0) return BadRequest();

            var desc = new Definition { Expressions = source };

            var generator = new DatapointGenerator(desc);
            var ts = generator.Sample(DEFAULT_PREVIEW_COUNT);

            return new JsonResult(ts);
        }
    }
}
