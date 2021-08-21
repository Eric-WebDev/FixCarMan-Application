using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Description { get; set; }
        public string RegistrationYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public string FuelType { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfDoors { get; set; }
        public double EngineSize { get; set; }
        public string Vin { get; set; }
        public string NCTResults { get; set; }
        public string VehicleServices { get; set; }
        public virtual AppUser VehicleOwner { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
       
    }
}
