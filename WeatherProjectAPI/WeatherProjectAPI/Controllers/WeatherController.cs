using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherProjectAPI.BL;
using RestSharp;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Cors;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IMapper _mapper;
        private IWeatherBL _weatherBL;

        public WeatherController(IMapper mapper, IWeatherBL weatherBL, ILogger<WeatherController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _weatherBL = weatherBL;
        }

        [HttpGet("SearchLocation")]
        public IActionResult SearchLocation([FromQuery(Name = "q")] string query)
        {
            IRestResponse response = _weatherBL.SearchLocation(query);
            return StatusCode((int)response.StatusCode, response.Content);
        }

        [HttpGet("{countryCode}")]
        public IActionResult GetWeather(string countryCode)
        {
            IRestResponse response = _weatherBL.GetWeather(countryCode);
            return StatusCode((int)response.StatusCode, response.Content); ;
        }

    }
}
