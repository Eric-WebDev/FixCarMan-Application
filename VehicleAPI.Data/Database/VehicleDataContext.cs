using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.API.Models;

namespace VehicleAPI.Data.Database
{
    public class VehicleDataContext:DbContext
    {
        public VehicleDataContext(DbContextOptions<VehicleDataContext> options)
          : base(options)
        {
        }
        public DbSet<VehicleProfile> UsersProfiles { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<NCTResult> NCTResults { get; set; }
        public DbSet<VehicleOwner> VehiclesOwners { get; set; }
        public DbSet<VehicleService> VehicleServices { get; set; }
        

    }
}
