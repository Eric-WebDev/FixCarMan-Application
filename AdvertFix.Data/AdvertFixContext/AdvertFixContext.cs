
using AdvertFix.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace AdvertFix.Data.AdvertFixContext
{
   public class AdvertFixContext : DbContext
    {
        public AdvertFixContext(DbContextOptions<AdvertFixContext> options)
       : base(options)
        {
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<Advert> Adverts { get; set; }
  
 
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Garage>().HasData(
        //             new Garage
        //             {
        //                 GarageId = 1,
        //                 CompanyName = "GarageFix",
        //                 URL = "www.GarageFix.test",
        //                 Street = "39 Connor Street",
        //                 City = "Sligo",
        //                 County = "Sligo",
        //             }
        //         );
        //}
    }
}
