using System;

namespace WeatherProjectAPI.DTO
{
    //TO DO
    //Add validation
    public class DTO_Favorite
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CityCode { get; set; }
    }
}