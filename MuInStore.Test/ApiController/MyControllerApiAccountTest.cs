using AutoFixture;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.Account;
using MuInShared.User;
using MuInStoreAPI.Models;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiAccountTest : SetupTest
    {
        [Fact]
        public async Task Login_ReturnsOkResult_WithValidCredentials()
        {
            // Arrange
            var appUser = _fixture.Create<AppUser>();
            var loginDto = new LoginDto
            {
                Username = appUser.UserName,
                Password = "valid_password",
            };

            _mockUserManager.Setup(x => x.Users).Returns(new List<AppUser> { appUser }.AsQueryable());
            _mockSignInManager.Setup(x => x.CheckPasswordSignInAsync(appUser, loginDto.Password, false))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);
            _mockTokenService.Setup(x => x.CreateToken(appUser)).Returns("test_token");

            // Act
            var result = await _accountController.Login(loginDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var newUserDto = Assert.IsType<NewUserDto>(okResult.Value);
            Assert.Equal(appUser.UserName, newUserDto.UserName);
            Assert.Equal(appUser.Id, newUserDto.UserId);
            Assert.Equal(appUser.Email, newUserDto.Email);
            Assert.Equal("test_token", newUserDto.Token);
        }

        [Fact]
        public async Task Register_ReturnsOkResult_WithValidUser()
        {
            // Arrange
            var registerDto = _fixture.Create<RegisterDto>();
            var appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(x => x.AddToRoleAsync(It.IsAny<AppUser>(), "User"))
                .ReturnsAsync(IdentityResult.Success);
            _mockTokenService.Setup(x => x.CreateToken(It.IsAny<AppUser>())).Returns("test_token");

            // Act
            var result = await _accountController.Register(registerDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var newUserDto = Assert.IsType<NewUserDto>(okResult.Value);
            Assert.Equal(registerDto.UserName, newUserDto.UserName);
            Assert.Equal(registerDto.Email, newUserDto.Email);
            Assert.Equal("test_token", newUserDto.Token);
        }

        [Fact]
        public async Task GetUserInfo_ReturnsOkResult_WithValidUserId()
        {
            // Arrange
            var userId = "test_user_id";
            var appUser = _fixture.Create<AppUser>();
            appUser.Id = userId;

            _mockUserManager.Setup(x => x.Users).Returns(new List<AppUser> { appUser }.AsQueryable());

            // Act
            var result = _accountController.GetUserInfo(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var userInfoDto = Assert.IsType<UserInfoDto>(okResult.Value);
            Assert.Equal(appUser.Id, userInfoDto.UserID);
            Assert.Equal(appUser.Email, userInfoDto.Email);
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenInvalidPassword()
        {
            // Arrange
            var appUser = _fixture.Create<AppUser>();
            var loginDto = new LoginDto
            {
                Username = appUser.UserName, // Assuming this username does not exist in the system
                Password = "invalid_password" // Assuming an invalid password for the test
            };

            _mockUserManager.Setup(x => x.Users).Returns(new List<AppUser>() { appUser }.AsQueryable());
            _mockSignInManager.Setup(x => x.CheckPasswordSignInAsync(appUser, loginDto.Password, false))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            // Act
            var result = await _accountController.Login(loginDto);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("User not found and/or password incorrect", unauthorizedResult.Value);
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenInvalidUserName()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                Username = "non_existing_username", // Assuming this username does not exist in the system
                Password = "invalid_password" // Assuming an invalid password for the test
            };

            _mockUserManager.Setup(x => x.Users).Returns(new List<AppUser>().AsQueryable());

            // Act
            var result = await _accountController.Login(loginDto);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Invalid UserName!", unauthorizedResult.Value);
        }

        [Fact]
        public async Task Login_ReturnsBadRequest_WhenInvalidLoginDto()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                Username = null, // Invalid: Username is null
                Password = "invalid_password" // Assuming a valid password for the test
            };

            _accountController.ModelState.AddModelError("Username", "The Username field is required.");

            // Act
            var result = await _accountController.Login(loginDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(_accountController.ModelState, _accountController.ModelState);
        }

        [Fact]
        public async Task Register_ReturnsStatusCode500_WhenRoleAssignmentFails()
        {
            // Arrange
            var registerDto = _fixture.Create<RegisterDto>();
            var appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            var roleError = new IdentityError { Code = "RoleError", Description = "Role assignment failed" };
            var roleResult = IdentityResult.Failed(roleError);

            _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<AppUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(x => x.AddToRoleAsync(It.IsAny<AppUser>(), "User"))
                .ReturnsAsync(roleResult); // Simulate role assignment failure
            _mockTokenService.Setup(x => x.CreateToken(It.IsAny<AppUser>())).Returns("test_token");

            // Act
            var result = await _accountController.Register(registerDto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
