using Microsoft.AspNetCore.Mvc;
using Nord.Helpers;
using Nord.Models;

namespace Nord.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherContext _context;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(WeatherContext context, ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get(int count)
    {
        return _context.WeatherForecasts.ToArray().Take(count);
    }
}
