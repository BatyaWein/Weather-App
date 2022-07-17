using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherProjectAPI.Entities;

namespace WeatherProjectAPI.DL
{
    public class FavoriteDL : IFavoriteDL
    {
        WeatherDBContext _weatherDBContext;
        public FavoriteDL(WeatherDBContext weatherDBContext)
        {
            _weatherDBContext = weatherDBContext;
        }

        public async Task<Favorite> AddToFavorite(Favorite favorite)
        {
            Favorite favoriteTask = null;
            if (await GetByUserIdAndCityCode(favorite.UserId, favorite.CityCode) != null)
            {
                return null;
            }
            try
            {
                await _weatherDBContext.Favorite.AddAsync(favorite);
                await _weatherDBContext.SaveChangesAsync();
                favoriteTask = await GetByUserIdAndCityCode(favorite.UserId, favorite.CityCode);
            }
            catch (Exception e)
            {
                //loggs
                Console.WriteLine(e);
            }
            return favoriteTask;
        }

        public async Task<List<Favorite>> GetByUserId(Guid userId)
        {
           List<Favorite> usersList = null;
            try
            {
                usersList= await _weatherDBContext.Favorite.Where(f => f.UserId.Equals(userId)).ToListAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return usersList;
        }

        public async Task<int> GetFavoriteAmount(Guid userId)
        {
            List<Favorite> usersList = await GetByUserId(userId);
            return usersList.Count;
        }

        private async Task<Favorite> GetByUserIdAndCityCode(Guid userId, string cityCode)
        {
            Favorite favorite = null;
            try
            {
                favorite =await _weatherDBContext.Favorite.Where(f => f.UserId.Equals(userId) && f.CityCode.Equals(cityCode)).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return favorite;
        }
    }
}
