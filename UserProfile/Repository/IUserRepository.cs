using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfile.Model;

namespace UserProfile.Repository
{
    interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int UserId);
        void AddUser(User user);
        void DeleteUser(int UserId);
        void UpdateUser(int UserId);
        void Save();
    }
}
