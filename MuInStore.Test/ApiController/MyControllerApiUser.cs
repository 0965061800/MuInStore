using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using MuInShared.User;
using MuInStoreAPI.Models;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiUserL : SetupTest
    {
        [Fact]
        public async Task GetAllAppUser_ReturnsOkResult_WithUsers()
        {
            // Arrange
            var users = _fixture.CreateMany<AppUser>(3).ToList();
            _mockUserManager.Setup(x => x.Users).Returns(users.AsQueryable());

            // Act
            var result = await _userController.GetAllAppUser();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnUsers = Assert.IsType<List<UserDto>>(okResult.Value);
            Assert.Equal(3, returnUsers.Count());
        }

        [Fact]
        public async Task GetAllAppUser_ReturnsNotFound_WhenNoUsersExist()
        {
            // Arrange
            _mockUserManager.Setup(um => um.Users).Returns(new List<AppUser>().AsQueryable());

            // Act
            var result = await _userController.GetAllAppUser();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("No User in your database", notFoundResult.Value);
        }

        [Fact]
        public async Task GetAppUser_ReturnsOkResult_WithUser()
        {
            // Arrange
            var user = _fixture.Build<AppUser>()
                .With(u => u.Orders, _fixture.CreateMany<Order>(2).ToList())
                .Create();

            foreach (var order in user.Orders)
            {
                order.Payment = _fixture.Create<Payment>();
                order.Payment.PayStatus = _fixture.Create<PayStatus>();
            }

            _mockUserManager.Setup(um => um.Users)
                .Returns(new List<AppUser> { user }.AsQueryable());

            // Act
            var result = await _userController.GetAppUser(user.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnUser = Assert.IsType<UserFullDto>(okResult.Value);
            Assert.Equal(user.UserName, returnUser.UserName);
        }
    }
}
