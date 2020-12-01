using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleAPI.Data.Models
{
    public class VehicleOwner
    {
        public int VehicleOwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<VehicleProfile> VehicleProfiles { get; set; }

    }
}
