using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models;
using System;
using System.Collections.Generic;

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
        public IEnumerable<string> Get()
        {
            return Catalog.Current.Keys;
        }

        // GET: api/Timeseries/5
        [HttpGet("{key}", Name = "Get")]
        public IEnumerable<IDatapoint> Get(string key)
        {
            return Catalog.Current[key].WithTimestamp();
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
