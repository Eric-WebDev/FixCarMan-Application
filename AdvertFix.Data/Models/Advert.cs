using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Data.Models
{
    public class Advert
    {
        public Guid Id { get; set; }
        public string CarModel { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Advertiser> UserAdverts { get; set; }
    }
}
