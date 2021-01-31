using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Domain.Models
{
    public class Advertiser
    {
        public int AdvertiserId { get; set; }
        public string AdvertiserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public virtual ICollection<Advert> AdvertOwner { get; set; }
    }
}
