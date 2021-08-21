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
        public DateTime DatePublished { get; set; }
        public bool IsAdvertCreator { get; set; }
    }
}
