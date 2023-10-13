using Microsoft.EntityFrameworkCore;
using Nord.Services;
using Nord.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WeatherContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("WeatherDatabase")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<WeatherService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
