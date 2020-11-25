using System;

namespace Vehicle.Data.Models
{
    public class NCTResult
    {
        public int NctResultId { get; set; }
        public string Odometer { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Comments { get; set; }
        public int VehicleProfileId { get; set; }
        public virtual VehicleProfile Vehicle { get; set; }
    }
}
