using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sequences;
using SimpleStackMachine;
using System;
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

        Lazy<StackMachine> SequencerEngine { get; set; }

        public TimeseriesController(IRepository<object> repository, IMemoryCache memoryCache)
        {
            SequencerEngine = new Lazy<StackMachine>(() => (StackMachine)memoryCache.GetOrCreate(Magic.SEQUENCE_BUILDER_KEY, entry => entry.Value = new StackMachine(typeof(SequenceCommands))));

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
            return Ok();
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
            return Ok();
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
            return Ok();
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
            return Ok();
        }
    }
}
