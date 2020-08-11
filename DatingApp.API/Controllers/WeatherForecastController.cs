using System;
using DatingApp.API.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
        private readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;

        }
         
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
           var values = await _context.Values.ToListAsync();
           return Ok(values);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value =_context.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }
    }
}
