using Engine;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly ITsRepository _repository;
        private readonly IGenerator _generator;

        public EngineController(ITsRepository repository, IGenerator generator)
        {
            _repository = repository;
            _generator = generator;
        }

        // GET: api/Timeseries/5
        [HttpGet("{id}")]
        public JsonResult Get(int id, [FromQuery]int? offset, [FromQuery]int? limit)
        {
            var desc = _repository.Read(id);
            var ts = _generator.Generate(desc).GetPage(offset, limit);

            return new JsonResult(ts);
        }

        // GET: api/Timeseries/5
        [HttpGet(Name = "Preview")]
        public JsonResult Get([FromQuery]ITsDescription desc, [FromQuery]int? offset, [FromQuery]int? limit)
        {
            var ts = _generator.Generate(desc).GetPage(offset, limit);
            return new JsonResult(ts);
        }
    }
}
