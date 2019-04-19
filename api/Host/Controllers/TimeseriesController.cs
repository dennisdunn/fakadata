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
        private readonly IRepository<object> _repository;
        private readonly IMemoryCache _memoryCache;

        private IStackMachine SequencerEngine => (IStackMachine)_memoryCache.GetOrCreate(Magic.SEQUENCE_BUILDER_KEY, entry => entry.Value = new StackMachine(typeof(SequenceCommands)));

        public TimeseriesController(IRepository<object> repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
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
            var series = (IEnumerable<object>)_memoryCache.Get(key);

            return new JsonResult(series.Take(count ?? 1));
        }

        // POST: api/Timeseries/key
        /// <summary>
        /// Load the sequence named 'key' into the cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpPost("{key}")]
        public IActionResult Post(string key)
        {
            throw new NotImplementedException();
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
    }
}
