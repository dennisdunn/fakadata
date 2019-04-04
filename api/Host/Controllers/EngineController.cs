using Engine;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;
using System.Collections.Generic;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        const int DEFAULT_PREVIEW_COUNT = 100;
        private readonly ITsRepository _repository;

        public EngineController(ITsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Timeseries/
        [HttpGet]
        public IActionResult Get([FromQuery]List<string> source, int? count)
        {
            if (source.Count == 0) return BadRequest();

            var desc = new TsDescription { Source = source };

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
