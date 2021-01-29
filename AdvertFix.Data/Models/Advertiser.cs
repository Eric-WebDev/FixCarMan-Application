using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Data.Models
{
    public class Advertiser
    {
        public int AdvertiserId { get; set; }
        public Guid AdvertId { get; set; }
        public virtual Advert AdvertFix { get; set; }
        public string AdvertiserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
