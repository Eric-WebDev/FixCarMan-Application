using Identity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Vehicles
{
    public class VehicleDto
    {
        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Description { get; set; }
        public string RegistrationYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string VehicleOwnerUsername { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public string FuelType { get; set; }
        public int? NumberOfSeats { get; set; }
        public int NumberOfDoors { get; set; }
        public double EngineSize { get; set; }
        public string Vin { get; set; }

    }
}
