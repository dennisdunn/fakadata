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
    public class TimeseriesController : ControllerBase
    {
        const int DEFAULT_PREVIEW_COUNT = 100;
        private readonly IDefinitionRepository _repository;
        private readonly IMemoryCache _memoryCache;

        public TimeseriesController(IDefinitionRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        // GET: api/Timeseries/key
        [HttpGet("{key}")]
        public IActionResult Get(string key, int? count)
        {
            if (!_memoryCache.TryGetValue(key, out IGenerator<IDatapoint> generator))
            {
                var desc = _repository.Read(key);
                if (desc == null) return NotFound();
                generator = new DatapointGenerator(desc);

                var options = new MemoryCacheEntryOptions()
                    .SetPriority(CacheItemPriority.NeverRemove);
                _memoryCache.Set(key, generator, options);
            }

            var ts = generator.Sample(count ?? DEFAULT_PREVIEW_COUNT);

            return new JsonResult(ts);
        }
    }
}
