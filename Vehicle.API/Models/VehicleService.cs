using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.API.Data
{
    public class VehicleService
    {
        public int ServiceId { get; set; }
        public string ServiceDetails { get; set; }
        public ServicesTypes ServiceType { get; set; }
        public string InvoiceURL { get; set; }
    }

    public enum ServicesTypes
    {
        AirConditioning,
        AirFilter,
        Battery,
        Belts,
        Body,
        Brakes,
        Cluth,
        Cooling,
        Engine,
        Exhaust,
        FuelSystem,
        Inspection,
        Lights,
        OilChange,
        Tyres,
        Radiator,
        SteeringSystem,
        SuspensionSystem,
        WheelAlignment,
        Other

    }
}
