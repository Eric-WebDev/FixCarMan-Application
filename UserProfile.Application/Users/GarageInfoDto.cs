using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfile.Application.Users
{
    public class GarageInfoDto
    {
        public string CompanyName { get; set; }

        public string ProfileDescription { get; set; }

        public string URL { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string ZipCode { get; set; }
        public bool IsUserGarage { get; set; }
        public string Image { get; set; }
    }
}
