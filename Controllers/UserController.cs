using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserManagmentApi.Models;

namespace UserManagmentApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static
        List<User> users = new List<User>
        {
    new User { Id = 1, Name = "Samuel", Email = "johndoe@example.com" },
    new User { Id = 2, Name = "Jane Smith", Email = "janesmith@example.com" },
    new User { Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
    new User { Id = 4, Name = "Michael Brown", Email = "michael.brown@example.com" },
    new User { Id = 5, Name = "Emily Davis", Email = "emily.davis@example.com" },
    new User { Id = 6, Name = "David Wilson", Email = "david.wilson@example.com" },
    new User { Id = 7, Name = "Sophia Martinez", Email = "sophia.martinez@example.com" },
    new User { Id = 8, Name = "James Taylor", Email = "james.taylor@example.com" },
    new User { Id = 9, Name = "Olivia Thomas", Email = "olivia.thomas@example.com" },
    new User { Id = 10, Name = "William Garcia", Email = "william.garcia@example.com" }
};

        //GET: api/users 
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(users);
        }

        //GET: api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        //POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser(User newUser)
        {
            newUser.Id = users.Max(u => u.Id) + 1; 
            users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }



        //PUT: api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return Ok(new
            {
                message = "User updated successfully",
                updatedUser = user
            });
        }


        //DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            users.Remove(user);
             return Ok(new
            {
                message = "User deleted successfully",
                deletedUser = user
            });
        }


    }
}