using Identity.Domain;

namespace Identity.Application.Interfaces
{
    public interface IJwtGenerator
    {
         string CreateToken(AppUser user);
    }
}