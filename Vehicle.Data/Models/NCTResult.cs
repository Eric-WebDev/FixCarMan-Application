﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Data.Models
{
    public class NCTResult
    {
        public int NctResultId { get; set; }
        public string Odometer { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Comments { get; set; }
        public VehicleProfile VehicleProfileNCT { get; set; }
    }
}