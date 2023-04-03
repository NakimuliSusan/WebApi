using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;
namespace WebApi.Controllers;

//The actions are exposed as HTTP endpoints via routing.So an HTTP GET request to
    //https://localhost:{PORT}/weatherforecast causes the Get() method of the
          //WeatherForecastController class to be executed.
//API Controller class attributes
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase // The weather forecast controller inherits from controller base class
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
    //HTTP GET method 
    [HttpGet(Name = "GetWeatherForecast")]

    // The attribute routes HTTP GET requests to the public IEnumerable<WeatherForecast> Get() method.
  
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
