﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;

        public EvalController(ITsRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
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

        //// GET: api/Timeseries/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id, int? count)
        //{
        //    if (!_memoryCache.TryGetValue(id, out IGenerator<IDatapoint> generator))
        //    {
        //        var desc = _repository.Read(id);
        //        if (desc == null) return NotFound();
        //        generator = new DatapointGenerator(desc);

        //        var options = new MemoryCacheEntryOptions()
        //            .SetPriority(CacheItemPriority.NeverRemove);
        //        _memoryCache.Set(id, generator, options);
        //    }

        //    var ts = generator.Sample(count ?? DEFAULT_PREVIEW_COUNT);

        //    return new JsonResult(ts);
        //}

        // GET: api/Timeseries/5
        [HttpGet("{name}")]
        public IActionResult Get(string name, int? count)
        {
            if (!_memoryCache.TryGetValue(name, out IGenerator<IDatapoint> generator))
            {
                var desc = _repository.Read(name);
                if (desc == null) return NotFound();
                generator = new DatapointGenerator(desc);

                var options = new MemoryCacheEntryOptions()
                    .SetPriority(CacheItemPriority.NeverRemove);
                _memoryCache.Set(name, generator, options);
            }

            var ts = generator.Sample(count ?? DEFAULT_PREVIEW_COUNT);

            return new JsonResult(ts);
        }
    }
}
