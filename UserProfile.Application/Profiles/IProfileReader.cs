using System.Threading.Tasks;

namespace UserProfile.Application.Profiles
{
    public interface IProfileReader
    {
         Task<Profile> ReadProfile(string username);
    }
}