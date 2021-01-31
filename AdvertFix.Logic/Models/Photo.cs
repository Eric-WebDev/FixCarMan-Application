using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Domain.Models
{
    public class Photo
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public virtual Advert PhotoAdvert { get; set; }
        //public virtual ICollection<Advert> AdvertPhotos { get; set; }
    }
}
