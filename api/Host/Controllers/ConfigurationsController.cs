using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Repository;
using System;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly ITsRepository _repository;

        public ConfigurationsController(ITsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Timeseries
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_repository.List());
        }

        // GET: api/Timeseries/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_repository.Read(id));
        }

        // POST: api/Timeseries
        [HttpPost]
        public void Post([FromBody] TsDescription value)
        {
            _repository.Create(value);
        }

        // PUT: api/Timeseries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TsDescription value)
        {
            _repository.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
