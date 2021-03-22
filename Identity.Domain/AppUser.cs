using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Identity.Domain
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string ProfileDescription { get; set; }

        public string URL { get; set; }

        public DateTime? Birthday { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string ZipCode { get; set; }
        public bool IsUserGarage { get; set; }
        public string AdvertId { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<UserAdvert> UserAdverts { get; set; }
       
    }
}

