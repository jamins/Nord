namespace Nord.Helpers;

using Microsoft.EntityFrameworkCore;
using Nord.Models;

public class WeatherContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public WeatherContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("WeatherDatabase"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>(entity => entity.HasKey(e => e.Id));
    }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

}

