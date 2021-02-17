
using Microsoft.EntityFrameworkCore;
using Identity.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityAPI.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserProfileDetails> AppUsersProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProfileDetails>(x => x.HasKey(ua =>
                new { ua.AppUserId }));

            builder.Entity<UserProfileDetails>()
                .HasOne(u => u.AppUser)
                .WithOne(a => a.UserProfileInfo)
                .HasForeignKey<UserProfileDetails>(u => u.AppUserId);
        }
    }
}
