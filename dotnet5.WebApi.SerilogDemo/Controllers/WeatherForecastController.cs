using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet5.WebApi.SerilogDemo.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("WeatherForecastController.Get() method get called");
            _logger.LogInformation("PI is {PI:0.00}", Math.PI);
            _logger.LogWarning("WeatherForecastController.Get() method get called");
            _logger.LogError("WeatherForecastController.Get() method get called");
            _logger.LogCritical("WeatherForecastController.Get() method get called");
            _logger.LogTrace("WeatherForecastController.Get() method get called");

            try
            {
                int i = 0;
                int j = 1;
                int k = j / i;
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
            }

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
