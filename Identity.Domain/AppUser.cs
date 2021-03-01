using Microsoft.AspNetCore.Identity;

namespace Identity.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayUserName { get; set; }
        public virtual UserProfileDetails UserProfileInfo { get; set; }
    }
}
