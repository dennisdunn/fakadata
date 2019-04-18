using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Timeseries.Api.Repository;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeseriesController : ControllerBase
    {
        const int DEFAULT_PREVIEW_COUNT = 100;
        private readonly IRepository<object> _repository;
        private readonly IMemoryCache _memoryCache;

        public TimeseriesController(IRepository<object> repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        // GET: api/Timeseries/key
        [HttpGet("{key}")]
        public IActionResult Get(string key, int? count)
        {
           return Ok();
        }
    }
}
