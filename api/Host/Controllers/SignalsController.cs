using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Timeseries.Api.Signals;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalsController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public SignalsController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        // GET: api/Signals
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Catalog.Current.Keys);
        }

        // GET: api/Signals/key
        [HttpGet("{key}")]
        public JsonResult Get(string key)
        {
            var result = Catalog.Current[key];
            return new JsonResult(result);
        }
    }
}
