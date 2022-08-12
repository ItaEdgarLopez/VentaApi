using Microsoft.AspNetCore.Mvc;

namespace WSVentaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
           List<WeatherForecast> lst = new List<WeatherForecast>();
            lst.Add(new WeatherForecast() { Id = 1, Nombre = "edgar" });
            lst.Add(new WeatherForecast() { Id = 2, Nombre = "debanhi" });
            lst.Add(new WeatherForecast() { Id = 3, Nombre = "Cualquiera" });



            return lst;
        }
    }
}