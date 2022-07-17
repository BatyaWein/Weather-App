using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeatherProjectAPI.BL;
using WeatherProjectAPI.DTO;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly ILogger<FavoriteController> _logger;
        private IFavoriteBL _favoriteBL;

        public FavoriteController(IFavoriteBL favoriteBL, ILogger<FavoriteController> logger)
        {
            _favoriteBL = favoriteBL;
            _logger = logger;
        }

        [HttpPost]
        public Task<DTO_Favorite> AddToFavorite([FromBody] DTO_Favorite favorite)
        {
            return _favoriteBL.AddToFavorite(favorite);
        }

        [Route("GetFavoriteAmount/{userId}")]
        [HttpGet]
        public Task<int> GetFavoriteAmount(Guid userId)
        {
            return _favoriteBL.GetFavoriteAmount(userId);
        }
    }
}
