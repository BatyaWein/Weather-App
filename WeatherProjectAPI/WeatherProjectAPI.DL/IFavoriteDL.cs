using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProjectAPI.Entities;

namespace WeatherProjectAPI.DL
{
    public interface IFavoriteDL
    {
        public Task<Favorite> AddToFavorite(Favorite user);
        public Task<List<Favorite>> GetByUserId(Guid userId);
        public Task<int> GetFavoriteAmount(Guid userId);
    }
}
