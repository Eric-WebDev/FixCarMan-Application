using Microsoft.EntityFrameworkCore;
using UserProfile.API.Models;

namespace UserProfile.API.DBContexts
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> UsersProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
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
