using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Timeseries.Api.Models;
using Timeseries.Api.Repository;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionsController : ControllerBase
    {
        private readonly IDefinitionRepository _repository;

        public DefinitionsController(IDefinitionRepository repository)
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
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_repository.Read(id));
        }

        // POST: api/Timeseries
        [HttpPost]
        public void Post([FromBody] Definition value)
        {
            _repository.Create(value);
        }

        // PUT: api/Timeseries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Definition value)
        {
            var cache = (IMemoryCache)HttpContext.RequestServices.GetService(typeof(IMemoryCache));
            cache.Remove(value.Name);

            _repository.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = _repository.Read(id);
            var cache = (IMemoryCache)HttpContext.RequestServices.GetService(typeof(IMemoryCache));
            cache.Remove(value.Name);

            _repository.Delete(value);
        }
    }
}
