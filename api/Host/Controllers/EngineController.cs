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

        public EngineController(ITsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Timeseries/
        [HttpGet("preview")]
        public JsonResult Get([FromQuery]TsDescription desc)
        {
            var generator = new DatapointGenerator(desc);
            var ts = generator.Sample();
            return new JsonResult(ts);
        }

        // GET: api/Timeseries/5
        [HttpGet("{id}")]
        public JsonResult Get(int id, int count)
        {
            var generator = new DatapointGenerator(_repository.Read(id));
            var ts = generator.Sample(count);
            return new JsonResult(ts);
        }
    }
}
