using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProjectAPI.DTO;

namespace WeatherProjectAPI.BL
{
    public interface IFavoriteBL
    {
        public Task<DTO_Favorite> AddToFavorite(DTO_Favorite favorite);
        public Task<int> GetFavoriteAmount(Guid userId);
    }
}
