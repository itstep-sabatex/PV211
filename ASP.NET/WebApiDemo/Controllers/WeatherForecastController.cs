 using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("WeatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITimeService _timeService;
        int a;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IConfiguration configuration,ITimeService timeService)
        {
            _logger = logger;
            _configuration = configuration;
            _timeService = timeService;
        }

        [HttpGet(Name = "GetWeatherForecast")] //GET  https://localhost:7600/WeatherForecast
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]

            })
            .ToArray();
        }
        [HttpGet("CurrentTime")] // GET /WeatherForecast/CurrentTime
        public DateTime   GetCurrentDate()
        {
            return _timeService.GetDateTime();

        }
    }
}
