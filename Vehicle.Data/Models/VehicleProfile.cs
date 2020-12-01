using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Data.Models
{
    public class VehicleProfile
    {
        public int VehicleProfileId { get; set; }
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
        public string ImageUrl { get; set; }
        public string County { get; set; }
        public int VehicleOwnerId { get; set; }
        public virtual VehicleOwner VehicleOwner { get; set; }
        public virtual ICollection<NCTResult> NCTResults { get; set; }    
        public virtual ICollection<VehicleService> VehicleServices { get; set; }
        public virtual ICollection<Garage> Garages { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
