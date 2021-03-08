using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain
{
    public class UserAdvert
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid AdvertId { get; set; }
        public virtual Advert Advert { get; set; }
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
