using Microsoft.EntityFrameworkCore;
using System;
using UserProfile.Model;

namespace UserProfile.DBContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid g = Guid.NewGuid();
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        FirstName = "John",
                        LastName = "Smyth",
                        CompanyName = "GarageFix",
                        ProfileDescription = "the best service",
                        Email = "GarageFix@email.com",
                        PhoneNumber = "0888555666",
                        URL = "www.GarageFix.test",
                        Birthday = null,
                        Street = "39 Connor Street",
                        City = "Sligo",
                        County = "Sligo",
                        ZipCode = "2GRE1",
                        IsUserGarage = true
                    }
                );
        }
    }
}
