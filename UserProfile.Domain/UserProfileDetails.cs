using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfile.Domain
{
    public class UserProfileDetails
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
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
        public string Image { get; set; }
    }
}
