using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WeatherProjectAPI.Entities
{
    //TO DO
    //Add validation
    public partial class User
    {
        public User()
        {
            Favorite = new HashSet<Favorite>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Favorite> Favorite { get; set; }
    }
}
