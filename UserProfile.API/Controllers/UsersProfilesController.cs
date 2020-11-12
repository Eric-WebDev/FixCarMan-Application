using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProfile.API.Models;
using UserProfile.API.Repository;

namespace UserProfile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersProfilesController : ControllerBase
    {
        private readonly IUserProfileRepository _userRepository;

        public UsersProfilesController(IUserProfileRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/<UsersController>
        // returns all users profiles data
        [HttpGet]
        public IActionResult Get()
        {
           var users = _userRepository.GetAllUsers();
            return new OkObjectResult(users);
        }


        // GET api/<UsersController>/5
        // returns user data specified by id number
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var users = _userRepository.GetUserByID(id);
            return new OkObjectResult(users);
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            using (var scope = new TransactionScope())
            {
                _userRepository.AddUser(user);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
        }


        // PUT api/<UsersController>/5
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (user != null)
            {
                using (var scope = new TransactionScope())
                {
                    _userRepository.UpdateUser(user);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.DeleteUser(id);
            return new OkResult();
        }
    }
}