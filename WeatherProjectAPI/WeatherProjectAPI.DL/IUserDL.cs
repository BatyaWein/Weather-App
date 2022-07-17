using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProjectAPI.Entities;

namespace WeatherProjectAPI.DL
{
    public interface IUserDL
    {
        public Task<User> createUser(User user);
        public Task<User> GetUser(string email, string password);
        public Task<User> GetUserById(Guid id);

    }
}
