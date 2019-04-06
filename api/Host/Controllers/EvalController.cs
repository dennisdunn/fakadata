using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Timeseries.Api.Evaluator;
using Timeseries.Api.Models;
using Timeseries.Api.Repository;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvalController : ControllerBase
    {
        const int DEFAULT_PREVIEW_COUNT = 100;
        private readonly ITsRepository _repository;

        public EvalController(ITsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Timeseries/
        [HttpGet]
        public IActionResult Get([FromQuery]List<string> source, int? count)
        {
            if (source.Count == 0) return BadRequest();

            var desc = new TsDescription { Expressions = source };

            var generator = new DatapointGenerator(desc);
            var ts = generator.Sample(count ?? DEFAULT_PREVIEW_COUNT);

            return new JsonResult(ts);
        }

        // GET: api/Timeseries/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, int? count)
        {
            var desc = _repository.Read(id);

            if (desc == null) return NotFound();

            var generator = new DatapointGenerator(desc);
            var ts = generator.Sample(count ?? DEFAULT_PREVIEW_COUNT);

            return new JsonResult(ts);
        }
    }
}
