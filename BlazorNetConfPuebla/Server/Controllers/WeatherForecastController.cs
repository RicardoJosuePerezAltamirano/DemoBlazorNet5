using BlazorNetConfPuebla.Shared;
using BlazorNetConfPuebla.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorNetConfPuebla.Server.Controllers
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
        Context dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,Context context)
        {
            _logger = logger;
            dbContext = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("Add")]
        public async Task<Registros> Add(string toAdd)
        {
            var a = await dbContext.AddAsync<Registros>(new Registros { Nombre = toAdd });
            await dbContext.SaveChangesAsync();
            return a.Entity;
        }
        [HttpGet("GetRegistros")]
        public async Task<List<Registros>> GetRegistros()
        {
            return await dbContext.Registros.ToListAsync();
        }
    }
}
