using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Domain.Models
{
    public class Advert
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CarModel { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
    
        public virtual ICollection <Photo> Photos { get; set; }
        public virtual Advertiser Advertiser { get; set; }
    }
}
