using Identity.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Data
{
    public class DataContext:IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsersProfiles { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<UserAdvert> UserAdverts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<AppUser>(x => x.HasIndex(ua =>
            //    new { ua.UserName }).IsUnique());

            builder.Entity<UserAdvert>(x => x.HasKey(ua =>
                new { ua.AppUserId, ua.AdvertId,ua.VehicleId }));

            builder.Entity<UserAdvert>()
                  .HasOne(u => u.AppUser)
                  .WithMany(a => a.UserAdverts)
                  .HasForeignKey(u => u.AppUserId);
            builder.Entity<UserAdvert>()
               .HasOne(a => a.Advert)
               .WithMany(u => u.UserAdverts)
               .HasForeignKey(a => a.AdvertId);
            builder.Entity<UserAdvert>()
               .HasOne(a => a.Vehicle)
               .WithMany(u => u.UserAdverts)
               .HasForeignKey(a => a.VehicleId);
        }
    }
}

