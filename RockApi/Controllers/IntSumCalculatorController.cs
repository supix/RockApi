using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetIntSum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace RockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntSumCalculatorController : ControllerBase
    {
        private readonly IQueryHandler<GetIntSumQuery, int> handler;

        public IntSumCalculatorController(IQueryHandler<GetIntSumQuery, int> handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        // GET api/IntSumCalculator
        [HttpGet]
        public ActionResult<int> Get([FromQuery] GetIntSumQuery query)
        {
            var jsonQuery = Newtonsoft.Json.JsonConvert.SerializeObject(query);
            var queryClass = query.GetType().ToString();
            Log.Information("Action starting {queryClass}: {jsonQuery}", queryClass, jsonQuery);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = this.handler.Handle(query);
            stopwatch.Stop();

            var elapsed = stopwatch.ElapsedMilliseconds;
            Log.Information("Action executed ({elapsed} ms)", elapsed);

            return result;
        }
    }
}