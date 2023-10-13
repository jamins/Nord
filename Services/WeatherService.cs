using Nord.Helpers;
using Nord.Models;

namespace Nord.Services
{
    public class WeatherService : BackgroundService
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(IServiceProvider serviceProvider, IConfiguration configuration,ILogger<WeatherService> logger)
        {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _logger = logger;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var context = scope.ServiceProvider.GetRequiredService<WeatherContext>();

                    var TemperatureC = Random.Shared.Next(-20, 55); ;
                    var temp = new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now),
                        TemperatureC = TemperatureC,
                        Summary = Temperature.Summary(TemperatureC)
                    };

                    await context.WeatherForecasts.AddAsync(temp);
                    await context.SaveChangesAsync();

                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }

                await Task.Delay(_configuration.GetValue<int>("WetherTimeUpdate"));
            }
        }
    }
}
