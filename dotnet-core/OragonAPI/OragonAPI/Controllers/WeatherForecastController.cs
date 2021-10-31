using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OragonAPI.Controllers
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
        private ILoggerManager _nlogger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoggerManager nlogger)
        {
            _logger = logger;
            _nlogger = nlogger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _nlogger.LogInfo("Here is info message from our values controller."); 
            _nlogger.LogDebug("Here is debug message from our values controller."); 
            _nlogger.LogWarn("Here is warn message from our values controller."); 
            _nlogger.LogError("Here is an error message from our values controller.");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
