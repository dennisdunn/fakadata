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
        public JsonResult Get(string key, [FromQuery] int? offset, [FromQuery]  int? limit)
        {
            var series = Catalog.Current[key].WithTimestamp();
            if (offset.HasValue && limit.HasValue)
            {
                return new JsonResult(series.Skip(offset.Value).Take(limit.Value));
            }
            else
            {
                return new JsonResult(series);
            }
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
