using UserProfile.Domain;

namespace UserProfile.Application.Interfaces
{
    public interface IJwtGenerator
    {
         string CreateToken(AppUser user);
    }
}