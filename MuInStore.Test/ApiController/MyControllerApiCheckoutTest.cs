using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.Checkout;
using MuInStoreAPI.Models;
using System.Security.Claims;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiCheckoutTest : SetupTest
    {
        [Fact]
        public async Task Checkout_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var requestCheckout = _fixture.Create<RequestCheckout>();
            var appUser = _fixture.Create<AppUser>();
            appUser.UserName = "testuser";
            var cart = requestCheckout.cart;
            var userInfo = requestCheckout.userInfo;

            // Mock HttpContext and User
            var httpContext = new DefaultHttpContext();
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.GivenName, "testuser") // Set the desired username here
            }));
            _checkoutController.ControllerContext = new ControllerContext { HttpContext = httpContext };

            _mockUserManager.Setup(x => x.FindByNameAsync("testuser")).ReturnsAsync(appUser);
            _mockUserManager.Setup(x => x.Users).Returns(new List<AppUser> { appUser }.AsQueryable());

            _mockUserManager.Setup(x => x.UpdateAsync(appUser)).ReturnsAsync(IdentityResult.Success);

            _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.CommitAsync()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.RollbackAsync()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.PaymentRepository.Create(It.IsAny<Payment>())).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.OrderRepository.Create(It.IsAny<Order>())).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.OrderDetailRepository.Create(It.IsAny<OrderDetail>())).Returns(Task.CompletedTask);

            // Act
            var result = await _checkoutController.Checkout(requestCheckout);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Checkout_ReturnsStatusCode500_WithInalidUsername()
        {
            // Arrange
            var requestCheckout = _fixture.Create<RequestCheckout>();
            var appUser = _fixture.Create<AppUser>();
            var cart = requestCheckout.cart;
            var userInfo = requestCheckout.userInfo;

            // Mock HttpContext and User
            var httpContext = new DefaultHttpContext();
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.GivenName, "testuser") // Set the desired username here
            }));
            _checkoutController.ControllerContext = new ControllerContext { HttpContext = httpContext };

            _mockUserManager.Setup(x => x.FindByNameAsync("testuser")).ReturnsAsync(appUser);
            _mockUserManager.Setup(x => x.Users).Returns(new List<AppUser> { appUser }.AsQueryable());

            _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.CommitAsync()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(x => x.RollbackAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await _checkoutController.Checkout(requestCheckout);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

    }
}
