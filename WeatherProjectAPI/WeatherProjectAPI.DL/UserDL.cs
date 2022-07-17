using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherProjectAPI.DL;
using WeatherProjectAPI.Entities;

namespace WeatherProjectAPI.DL
{
    //TO DO
    //Add Logs
    public class UserDL : IUserDL
    {
        WeatherDBContext _weatherDBContext;
        public UserDL(WeatherDBContext weatherDBContext)
        {
            _weatherDBContext = weatherDBContext;
        }

        public async Task<User> createUser(User user)
        {
            try
            {
                await _weatherDBContext.User.AddAsync(user);
                await _weatherDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return await GetUser(user.Email, user.Password);
        }

        public async Task<User> GetUser(string email, string password)
        {
            User user = null;
            try
            {
                user = await _weatherDBContext.User.
                 Where(u => (u.Email.Equals(email)) &&
                 (u.Password.Equals(password))).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                //logs
                Console.WriteLine(e);
            }
            return user;
        }
        public async Task<User> GetUserById(Guid id)
        {
            User user = null;
            try
            {
                user = await _weatherDBContext.User.
                 Where(u => (u.Id.Equals(id))).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                //logs
                Console.WriteLine(e);
            }
            return user;
        }
    }
}
