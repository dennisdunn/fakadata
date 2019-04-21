using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sequences;
using SimpleStackMachine;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Repository;
using System;
using Timeseries.Api.Services;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeseriesController : ControllerBase
    {
        private readonly IRepository<Doc> _repository;
        private readonly IStackMachine _stackMachine;
        private readonly IMemoryCache _memoryCache;

        public TimeseriesController(IRepository<Doc> repository, IMemoryCache memoryCache, IStackMachine stackMachine)
        {
            _repository = repository;
            _memoryCache = memoryCache;
            _stackMachine = stackMachine;
        }

        // GET: api/Timeseries
        /// <summary>
        /// Get the names of the cached sequences.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var names = SequenceFactory.List();
            names = names.Concat(_memoryCache.Keys());

            return new JsonResult(names);
        }

        // GET: api/Timeseries/key
        /// <summary>
        /// Get points from the cached sequence named 'key'.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("{key}")]
        public IActionResult Get(string key, int? count)
        {
            var series = _memoryCache.GetOrCreate(key, entry => MakeSequence(key));

            return new JsonResult(series.Take(count ?? 1));
        }

        // DELETE: api/Timeseries/key
        /// <summary>
        /// Remove the sequence named 'key' from the cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            _memoryCache.Remove(key);

            return Ok();
        }

        private IEnumerable<double> MakeSequence(string key)
        {
            if (SequenceFactory.List().Contains(key))
            {
                return SequenceFactory.Load(key);
            }
            else
            {
                var doc = _repository.Read(key);
                if (doc != null)
                {
                    _stackMachine.Eval((string[])doc.Value);
                }
            }
            throw new ArgumentException("key");
        }
    }
}
