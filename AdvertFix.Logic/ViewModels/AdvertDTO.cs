using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertFix.Domain.ViewModels
{
    public class AdvertDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CarModel { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        [JsonProperty("advertisers")]
        public virtual ICollection<AdvertiserDTO> UserAdverts { get; set; }
    }
}
