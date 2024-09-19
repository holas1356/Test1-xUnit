using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserManagmentApi.Controllers;
using UserManagmentApi.Models;
using Xunit;

namespace UserManagementApi.Tests
{
    public class UsersControllerTests
    {
        [Fact]
        public void GetUsers_ReturnsOkResult()
        {
           
            var controller = new UsersController();

          
            var result = controller.GetUsers();

        
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public void GetUsers_ReturnsOkResult_WithListOfUsers()
        {
            
            var controller = new UsersController();

          
            var result = controller.GetUsers();

           
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var users = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);
            Assert.Equal(10, users.Count()); 
        }

        [Fact]
        public void GetUsers_ReturnsAllUsers()
        {
           
            var controller = new UsersController();

          
            var result = controller.GetUsers();

          
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var users = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);

           
            foreach (var user in users)
            {
                Assert.NotNull(user.Name);
                Assert.NotNull(user.Email);
            }
        }

         [Fact]
        public void GetUsers_ContainsExpectedUsers()
        {
        
            var controller = new UsersController();
            var expectedUsers = new List<string>
            {
                "John Doe",
                "Jane Smith",
                "Alice Johnson",
                "Michael Brown",
                "Emily Davis",
                "David Wilson",
                "Sophia Martinez",
                "James Taylor",
                "Olivia Thomas",
                "William Garcia"
            };

       
            var result = controller.GetUsers();

         
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var users = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);

            foreach (var user in users)
            {
                Assert.Contains(user.Name, expectedUsers);
            }
        }
    }
}
