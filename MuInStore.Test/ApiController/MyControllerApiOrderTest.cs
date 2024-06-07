using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.Order;
using MuInStoreAPI.Models;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiOrderTest : SetupTest
    {
        [Fact]
        public async Task GetAllOrder_ReturnsOkResult_WithOrders()
        {
            // Arrange
            var orders = _fixture.CreateMany<Order>().ToList();
            _mockOrderRepo.Setup(repo => repo.GetAllOrderAsync(It.IsAny<Expression<Func<Order, bool>>>(), null)).ReturnsAsync(orders);

            // Act
            var result = await _orderController.GetAllOrder();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnOrders = Assert.IsType<List<OrderDto>>(okResult.Value);
            Assert.Equal(orders.Count, returnOrders.Count);
        }

        [Fact]
        public async Task GetOrderById_ReturnsOkResult_WithOrder()
        {
            // Arrange
            var order = _fixture.Create<Order>();
            _mockOrderRepo.Setup(repo => repo.GetOrderById(order.OrderId)).ReturnsAsync(order);

            // Act
            var result = await _orderController.GetOrderById(order.OrderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnOrder = Assert.IsType<OrderFullDto>(okResult.Value);
            Assert.Equal(order.OrderId, returnOrder.OrderId);
        }

        [Fact]
        public async Task GetOrderById_ReturnsNotFoundResult_WhenOrderNotFound()
        {
            // Arrange
            _mockOrderRepo.Setup(repo => repo.GetOrderById(It.IsAny<int>())).ReturnsAsync((Order)null);

            // Act
            var result = await _orderController.GetOrderById(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        //[Fact]
        public async Task GetOrderByName_ReturnsOkResult_WithOrders()
        {
            // Arrange
            var orders = _fixture.CreateMany<Order>().ToList();
            var username = "testuser";
            var httpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }))
            };
            _orderController.ControllerContext = new ControllerContext { HttpContext = httpContext };
            _mockOrderRepo.Setup(repo => repo.GetOrderByUserName(username)).ReturnsAsync(orders);

            // Act
            var result = await _orderController.GetOrderByName();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnOrders = Assert.IsType<List<OrderFullDto>>(okResult.Value);
            Assert.Equal(orders.Count, returnOrders.Count);
        }

        [Fact]
        public async Task GetOrderByName_ReturnsNotFoundResult_WhenNoOrdersFound()
        {
            // Arrange
            var username = "testuser";
            var httpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.GivenName, username)
                }))
            };
            _orderController.ControllerContext = new ControllerContext { HttpContext = httpContext };
            _mockOrderRepo.Setup(repo => repo.GetOrderByUserName(username)).ReturnsAsync((List<Order>)null);

            // Act
            var result = await _orderController.GetOrderByName();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
