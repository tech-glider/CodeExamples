using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TG.Code.ConfiguratonAPI.Configuration;

namespace TG.Code.ConfiguratonAPI.Controllers
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
        private readonly IOptions<OptionsConfig> options;
        private readonly IOptionsSnapshot<OptionsConfig> optionsSnapshot;
        private readonly IOptionsMonitor<OptionsConfig> optionsMonitor;
        private readonly IConfiguration configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IOptions<OptionsConfig> options,
            IOptionsSnapshot<OptionsConfig> optionsSnapshot,
            IOptionsMonitor<OptionsConfig> optionsMonitor,
            IConfiguration configuration)
        {
            _logger = logger;
            this.options = options;
            this.optionsSnapshot = optionsSnapshot;
            this.optionsMonitor = optionsMonitor;
            this.configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var optionsCS = options.Value.ConnectionString;
            var optionsSnapshotCS = optionsSnapshot.Value.ConnectionString;
            var optionsMonitorCs = optionsMonitor.CurrentValue.ConnectionString;
            var configurationCS = configuration.GetSection("SectionOptions")["ConnectionString"];
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}