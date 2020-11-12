using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfile.API.Models;

namespace UserProfile.API.Repository
{
    public interface IUserProfileRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int UserId);
        void AddUser(User user);
        void DeleteUser(int UserId);
        void UpdateUser(User user);
        void Save();
    }
}
