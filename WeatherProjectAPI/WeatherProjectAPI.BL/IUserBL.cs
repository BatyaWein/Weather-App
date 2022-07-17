using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherProjectAPI.DTO;
using WeatherProjectAPI.Entities;

namespace WeatherProjectAPI.BL
{
    public interface IUserBL
    {
        public Task<DTO_User> createUser(DTO_User user);
        public Task<DTO_User> GetUser(string email, string password);
        public Task<DTO_User> GetUserById(Guid id);

    }
}
