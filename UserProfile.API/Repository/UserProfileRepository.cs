using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProfile.API.DBContexts;
using UserProfile.API.Models;

namespace UserProfile.API.Repository
{
    public class UserProfileRepository:IUserProfileRepository
    {
        private readonly UserContext _dbContext;
        public UserProfileRepository(UserContext context)
        {
            _dbContext = context;
        }
        public void AddUser(User user)
            {
                _dbContext.Add(user);
                Save();
            }

            public void DeleteUser(int userId)
            {
                var user = _dbContext.UsersProfiles.Find(userId);
                _dbContext.UsersProfiles.Remove(user);
                Save();
            }

            public IEnumerable<User> GetAllUsers()
            {
                return _dbContext.UsersProfiles.ToList();
            }

            public User GetUserByID(int userId)
            {
                return _dbContext.UsersProfiles.Find(userId);
            }

            public void Save()
            {
                _dbContext.SaveChanges();
            }

            public void UpdateUser(User user)
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                Save();
            }
        }
    }
