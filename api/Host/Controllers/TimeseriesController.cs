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
            return new JsonResult(Catalog.Current.Keys.OrderBy(key => key));
        }

        // GET: api/Timeseries/5
        [HttpGet("{key}", Name = "Get")]
        public JsonResult Get(string key)
        {
            return new JsonResult(Catalog.Current[key].WithTimestamp());
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
