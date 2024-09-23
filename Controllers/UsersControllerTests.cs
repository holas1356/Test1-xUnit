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
                "Samuel",
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

        [Fact]
        public void GetUserById_ReturnsOkResult_ForExistingUser()
        {
            var controller = new UsersController();

            var result = controller.GetUserById(3);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var user = Assert.IsType<User>(okResult.Value);
            Assert.Equal(3, user.Id);
        }

        [Fact]
        public void GetUserById_ReturnsNotFound_ForNonExistingUser()
        {
            var controller = new UsersController();

            var result = controller.GetUserById(99);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateUser_ReturnsCreatedResult()
        {
            var controller = new UsersController();
            var newUser = new User { Name = "Test User", Email = "test@example.com" };

            var result = controller.CreateUser(newUser);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdUser = Assert.IsType<User>(createdAtActionResult.Value);
            Assert.Equal("Test User", createdUser.Name);
        }

        [Fact]
        public void UpdateUser_ReturnsOkResult_ForExistingUser()
        {
            var controller = new UsersController();
            var updatedUser = new User { Name = "Updated Name", Email = "updated@example.com" };

            var result = controller.UpdateUser(1, updatedUser);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseBody = okResult.Value as dynamic;

            Assert.NotNull(responseBody);

            var updatedUserResponse = responseBody?.updatedUser as User;

            Assert.NotNull(updatedUserResponse);

            Assert.Equal("Updated Name", updatedUserResponse?.Name);
            Assert.Equal("updated@example.com", updatedUserResponse?.Email);
        }

        [Fact]
        public void DeleteUser_ReturnsOkResult_ForExistingUser()
        {
            var controller = new UsersController();

            var result = controller.DeleteUser(2);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseBody = okResult.Value as dynamic;

            Assert.NotNull(responseBody);

            var deletedUser = responseBody?.deletedUser as User;

            Assert.NotNull(deletedUser);

            Assert.Equal(2, deletedUser?.Id);
        }


    }
}
