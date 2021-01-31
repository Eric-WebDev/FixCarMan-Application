using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Domain.ViewModels
{
    public class AdvertiserDTO
    {
        public int AdvertiserId { get; set; }
        public Guid AdvertId { get; set; }
        public string AdvertiserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
