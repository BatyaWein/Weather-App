using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using WeatherProjectAPI.DL;
using WeatherProjectAPI.DTO;
using WeatherProjectAPI.Entities;

namespace WeatherProjectAPI.BL
{
    public class FavoriteBL : IFavoriteBL
    {
        IFavoriteDL _favoriteDL;
        private readonly IMapper _mapper;
        public FavoriteBL(IFavoriteDL favoriteDL, IMapper mapper)
        {
            _favoriteDL = favoriteDL;
            _mapper = mapper;
        }


        public async Task<DTO_Favorite> AddToFavorite(DTO_Favorite favorite)
        {
            Favorite newFavorite= _mapper.Map<DTO_Favorite, Favorite>(favorite);
            newFavorite=await _favoriteDL.AddToFavorite(newFavorite);
            if (newFavorite == null)
            {
                //logs
                throw new HttpResponseException(HttpStatusCode.NotFound);
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
