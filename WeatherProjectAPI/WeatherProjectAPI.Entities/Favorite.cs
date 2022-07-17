using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeatherProjectAPI.Entities
{
    //TO DO
    //Add validation
    public partial class Favorite
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CityCode { get; set; }

        public virtual User User { get; set; }
    }
}
