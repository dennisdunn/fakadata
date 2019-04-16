using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Timeseries.Api.Models;
using Timeseries.Api.Repository;
using Timeseries.Api.Signals;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalsController : ControllerBase
    {
        private readonly IRepository<Signal> _repository;

        public SignalsController(IRepository<Signal> repository)
        {
            _repository = repository;
        }

        // GET: api/Signals
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Catalog.Names.Select(x => new { label = x, value = -1 }).Concat(_repository.List()));
        }

        // GET: api/Signals/key
        [HttpGet("{key}")]
        public JsonResult Get(string key, int? count)
        {
            IEnumerable<double> generator;

            if (Catalog.Names.Contains(key))
            {
                generator = SignalFactory.FromCatalog(key);
            }
            else
            {
                var expr = _repository.Read(key);
                generator = SignalFactory.FromExpression(expr.Expression);
            }

            var ts = generator.Take(count ?? Constants.DEFAULT_PREVIEW_COUNT);

            return new JsonResult(ts);
        }

        // POST: api/Signals
        [HttpPost]
        public void Post([FromBody] Signal value)
        {
            _repository.Create(value);
        }

        // PUT: api/Signals/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Signal value)
        {
            _repository.Update(value);
        }

        // DELETE: api/Signals/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _repository.Read(id);
            _repository.Delete(item);
        }
    }
}
