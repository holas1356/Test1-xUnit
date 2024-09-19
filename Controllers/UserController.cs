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
    new User { Id = 1, Name = "John Doe", Email = "johndoe@example.com" },
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
    }
}