﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using Timeseries.Api.Evaluator;
using Timeseries.Api.Models;
using Timeseries.Api.Repository;

namespace Timeseries.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IRepository<Definition> _repository;

        public PreviewController(IRepository<Definition> repository)
        {
            _repository = repository;
        }

        // GET: api/Preview/source
        [HttpGet]
        public IActionResult Get([FromQuery]List<string> source)
        {
            if (source.Count == 0) return BadRequest();

            var desc = new Definition { Expressions = source };

            var generator = new DatapointGenerator(desc);
            var ts = generator.Sample(Constants.DEFAULT_PREVIEW_COUNT);

            return new JsonResult(ts);
        }
    }
}
