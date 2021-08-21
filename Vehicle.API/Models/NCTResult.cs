using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.API.Data
{
    public class NCTResult
    {
        public int NctResultId { get; set; }
        public string Odometer { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Comments { get; set; }
        public List<VehicleProfile> VehicleProfiles  { get; set; }

    }
}
