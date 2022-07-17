using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WeatherProjectAPI.DL;
using WeatherProjectAPI.DTO;
using WeatherProjectAPI.Entities;

namespace WeatherProjectAPI.BL
{
    public class FavoriteBL : IFavoriteBL
    {
        private readonly IFavoriteDL _favoriteDL;
        private readonly ILogger<FavoriteBL> _logger;
        private readonly IMapper _mapper;
        public FavoriteBL(IFavoriteDL favoriteDL, IMapper mapper, ILogger<FavoriteBL> logger)
        {
            _favoriteDL = favoriteDL;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<DTO_Favorite> AddToFavorite(DTO_Favorite favorite)
        {
            Favorite newFavorite= _mapper.Map<DTO_Favorite, Favorite>(favorite);
            newFavorite=await _favoriteDL.AddToFavorite(newFavorite);
            if (newFavorite == null)
            {
                _logger.LogWarning($"Add cityCode: {favorite.CityCode} to favorite for user: {favorite.UserId} is already exist");

                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            DTO_Favorite dtoFavorite = _mapper.Map<Favorite, DTO_Favorite>(newFavorite);
            return dtoFavorite;
        }

        public async Task<int> GetFavoriteAmount(Guid userId)
        {
            int favoriteAmount = await _favoriteDL.GetFavoriteAmount(userId);
            return favoriteAmount;
        }
    }
}
