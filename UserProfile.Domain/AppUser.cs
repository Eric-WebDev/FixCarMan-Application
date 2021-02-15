using Microsoft.AspNetCore.Identity;
using System;

namespace UserProfile.Domain
{
    public class AppUser : IdentityUser
    {
        public string Username { get; set; }
        public virtual UserProfileDetails UserProfileInfo { get; set; }
    }
}