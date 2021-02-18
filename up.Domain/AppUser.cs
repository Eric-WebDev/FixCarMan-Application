using System;
using Microsoft.AspNetCore.Identity;
namespace Identity.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayUsername { get; set; }
        public virtual UserProfileDetails UserProfileInfo { get; set; }
    }
}