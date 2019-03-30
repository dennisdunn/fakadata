using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models;
using System;
using System.Linq;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeseriesController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public TimeseriesController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        // GET: api/Timeseries
        [HttpGet]
        public JsonResult Get()
        {
            var i = 0;
            var keys = Catalog.Current.Keys.OrderBy(key => key).Select(key => new { key = i++, value = key });
            return new JsonResult(keys);
        }

        // GET: api/Timeseries/5
        [HttpGet("{key}", Name = "Get")]
        public JsonResult Get(string key)
        {
            var result = Catalog.Current[key].WithTimestamp().ToList();
            return new JsonResult(result);
        }

        // POST: api/Timeseries
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Timeseries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
