using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Data.Models;

namespace Vehicle.Data.DBContexts
{
    public class VehicleContext: DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options)
        : base(options)
        {
        }

        public DbSet<VehicleOwner> VehicleOwners { get; set; }
        public DbSet<VehicleProfile> VehicleProfiles { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public DbSet<NCTResult> NCTResults { get; set; }
        public DbSet<VehicleService> VehicleServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
