using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadPay724.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return "value";
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost]
        public async Task<string> Post([FromBody] string vlaue)
        {
            return null;
        }
        [HttpPut ("{id}")]
        async Task<string> Put(int id, [FromBody] string vlaue)
        {
            return null;
        }
        [HttpDelete("{id}")]
        async Task<string> Delete(int id)
        {
            return null;
        }
    }
}
