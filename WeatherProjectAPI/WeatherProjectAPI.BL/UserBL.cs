using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class UserBL : IUserBL
    {

        IUserDL _userDL;
        private readonly IMapper _mapper;
        private readonly ILogger<UserBL> _logger;
        public UserBL(IUserDL userDL, IMapper mapper, ILogger<UserBL> logger)
        {
            _userDL = userDL;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DTO_User> createUser(DTO_User user)
        {
            User entityUser = _mapper.Map<DTO_User, User>(user);
            entityUser = await _userDL.createUser(entityUser);
            DTO_User dtoUser = _mapper.Map<User, DTO_User>(entityUser);
            return dtoUser;
        }

        public async Task<DTO_User> GetUser(string email, string password)
        {
            User user = await _userDL.GetUser(email, password);
            if (user == null)
            {
                _logger.LogWarning($"The user email: {email} and password: {password} does not exist");
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            DTO_User dtoUser = _mapper.Map<User, DTO_User>(user);
            return dtoUser;
        }
        public async Task<DTO_User> GetUserById(Guid id)
        {
            User user = await _userDL.GetUserById(id);
            if (user == null)
            {
                _logger.LogWarning($"The userId {id}  does not exist");
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            DTO_User dtoUser = _mapper.Map<User, DTO_User>(user);
            return dtoUser;
        }
    }
}
