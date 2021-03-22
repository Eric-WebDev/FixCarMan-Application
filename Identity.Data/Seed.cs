using Identity.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
           UserManager<AppUser> userManager)
        {
           if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        UserName = "bob",
                        Email = "bob@test.com",
                        FirstName = "Tom",
                        LastName = "Got",
                        CompanyName = "CarFix",
                        ProfileDescription= "the best service",
                        URL = "www.CarFix.test",
                        Birthday =  null,
                        Street =  "39 Avenue",
                        City = "Sligo",
                        County = "Sligo",
                        ZipCode =  "2GRE1",
                        IsUserGarage =  true

                    },
                    new AppUser
                    {
                        Id = "b",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        Id = "c",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
           if (!context.Adverts.Any())
           {
                var adverts = new List<Advert>
                {
                    new Advert
                    {
                        Title = "Fix car 1 / bob",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Advert 2 months ago",
                        CarModel = "BMW",
                        City = "Sligo",
                        UserAdvert = new UserAdvert
                        {
                                AppUserId = "a",
                                DatePublished = DateTime.Now.AddMonths(-2),
                                IsAdvertCreator=true,                               

                        }
                    },
                    new Advert
                    {
                        Title = "Fix car 2 / jane",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Advert 1 months ago",
                        CarModel = "Audi",
                        City = "Sligo",
                        UserAdvert = new UserAdvert
                        {
                           
                                AppUserId = "b",
                                DatePublished = DateTime.Now.AddMonths(-1),
                                IsAdvertCreator=true
    
                        }
                    }
                };
                await context.Adverts.AddRangeAsync(adverts);
                await context.SaveChangesAsync();
           }
        }
    }
}