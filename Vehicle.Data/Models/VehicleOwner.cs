using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Data.Models
{
    public class VehicleOwner
    {
        public int VehicleOwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<VehicleProfile> VehicleProfiles { get; set; }

    }
}
