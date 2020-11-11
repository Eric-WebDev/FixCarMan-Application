using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfile.DBContexts;
using UserProfile.Model;

namespace UserProfile.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;
        public void AddUser(User user)
        {
            _dbContext.Add(user);
            Save();
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            _dbContext.Users.Remove(user);
            Save();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserByID(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateUser(int userId)
        {
            _dbContext.Entry(userId).State = EntityState.Modified;
            Save();
        }
    }
}
