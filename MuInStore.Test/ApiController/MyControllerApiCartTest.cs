using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.Cart;
using System.Linq.Expressions;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiCartTest : SetupTest
    {
        [Fact]
        public async Task GetCartDetail_ReturnsOkResult_WithCartItems()
        {
            // Arrange
            var cartItems = _fixture.CreateMany<AddToCartVM>().ToList();
            var productSkus = _fixture.CreateMany<ProductSku>().ToList();

            _mockProductSkuRepo.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<ProductSku, bool>>>(), null, "Color,Product")).ReturnsAsync(productSkus);

            // Act
            var result = await _cartController.GetCartDetail(cartItems);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCartItems = Assert.IsType<List<CartItemReponse>>(okResult.Value);
            Assert.Equal(cartItems.Count, returnCartItems.Count);
        }

        [Fact]
        public async Task GetCartDetail_ReturnsOkResult_WithEmptyCartItems()
        {
            // Arrange
            var cartItems = new List<AddToCartVM>();

            // Act
            var result = await _cartController.GetCartDetail(cartItems);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCartItems = Assert.IsType<List<CartItemReponse>>(okResult.Value);
            Assert.Empty(returnCartItems);
        }
    }
}
