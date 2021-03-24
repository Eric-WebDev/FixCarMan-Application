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

    }
}
