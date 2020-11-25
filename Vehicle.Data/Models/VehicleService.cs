using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Data.Models
{
    public class VehicleService
    {
        public int VehicleServiceId { get; set; }
        public string ServiceDetails { get; set; }
        public virtual ServicesTypes ServiceType { get; set; }
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
