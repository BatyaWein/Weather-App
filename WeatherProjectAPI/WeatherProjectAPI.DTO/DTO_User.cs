using System;

namespace WeatherProjectAPI.DTO
{
    //TO DO
    //Add validation
    public class DTO_User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}