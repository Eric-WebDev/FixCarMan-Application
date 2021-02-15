using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserProfile.Application.Errors;
using UserProfile.Application.Interfaces;
using UserProfile.Persistance;

namespace UserProfile.Application.Profiles
{
    public class ProfileReader : IProfileReader
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        public ProfileReader(DataContext context, IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
            _context = context;
        }

        public async Task<Profile> ReadProfile(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);

            var currentUser = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());

            var profile = new Profile
            {
                Username = user.UserName,
                Image=user.UserProfileInfo.Image,
                Description=user.UserProfileInfo.ProfileDescription
            };

            return profile;
        }
    }
}