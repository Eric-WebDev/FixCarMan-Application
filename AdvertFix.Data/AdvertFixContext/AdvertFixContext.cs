
using AdvertFix.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        DateTime aDay = DateTime.Now;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advert>().HasData(
                
                new Advert
                     {
                         CarModel = "BMW",
                         Title = " unusual noise",
                         Description = "car has a metallic grinding coming from the left rear when I press the brake.",
                         Date = aDay,
                         City= "Sligo",
                         Photos = new List<Photo> 
                         {
                             new Photo
                             {
                                 Url="https://www.google.com/search?q=bmw&sxsrf=ALeKk017PtP5DLSQa7Mj-3E_3sIqlFx9fg:1611950748060&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiA4u69-MHuAhWyp3EKHSQbAQ8Q_AUoAXoECAoQAw&biw=1920&bih=977#imgrc=KnLCcXX0zO5QGM",
                                 IsMain=true
                             }
                         }
                     }
                 );
        }
    }
}
