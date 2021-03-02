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

            //if (!context.AppUsersProfiles.Any())
            //{
            //    var profile = new List<UserProfileDetails>
            //    {
            //        new UserProfileDetails
            //        {
            //            AppUserId = "a",
            //            FirstName = "Tom",
            //            LastName = "Got",
            //            CompanyName = "CarFix",
            //            ProfileDescription= "the best service",
            //            URL = "www.CarFix.test",
            //            Birthday =  null,
            //            Street =  "39 Avenue",
            //            City = "Sligo",
            //            County = "Sligo",
            //            ZipCode =  "2GRE1",
            //            IsUserGarage =  true
            //        },

            //    };
            //    await context.AppUsersProfiles.AddRangeAsync(profile);
                await context.SaveChangesAsync();
            }
        }
    }

