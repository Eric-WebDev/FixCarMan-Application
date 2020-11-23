using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleProfile.API.Models
{
    public class Garage
    {
        public int GarageId { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string URL { get; set; }
        public List<VehicleProfile> VehicleProfiles { get; set; }
    }
}
