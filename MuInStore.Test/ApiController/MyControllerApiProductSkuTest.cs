using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.ProductSku;
using MuInStoreAPI.Models;
using System.Linq.Expressions;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiProductSkuTest : SetupTest
    {
        [Fact]
        public async Task GetById_ReturnsOkResult_WithValidId()
        {
            // Arrange
            var productSku = _fixture.Create<ProductSku>();
            var id = productSku.ProductSkuId;

            _mockProductSkuRepo.Setup(x => x.GetById(id)).ReturnsAsync(productSku);

            // Act
            var result = await _productSkuController.GetById(id);
            // Assert
            var actionResult = Assert.IsType<ActionResult<ProductSkuFullDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WithInvalidId()
        {
            // Arrange
            var invalidId = -1; // Assuming an ID that doesn't exist

            _mockProductSkuRepo.Setup(x => x.GetById(invalidId)).ReturnsAsync((ProductSku)null);

            // Act
            var result = await _productSkuController.GetById(invalidId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ProductSkuFullDto>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetByColorAndProduct_ReturnsOkResult_WithValidParameters()
        {
            // Arrange
            var productId = 1;
            var colorId = 1;
            var productSku = _fixture.Create<ProductSku>();
            var productSkuList = new List<ProductSku> { productSku };

            _mockProductSkuRepo.Setup(x => x.GetAll(
               It.IsAny<Expression<Func<ProductSku, bool>>>(),
               It.IsAny<Func<IQueryable<ProductSku>, IOrderedQueryable<ProductSku>>>(),
               It.IsAny<string>()))
               .ReturnsAsync(productSkuList);

            // Act
            var result = await _productSkuController.GetByColorAndProduct(productId, colorId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProductSkuDto = Assert.IsType<ProductSkuDto>(okResult.Value);
            // Add more detailed assertions as needed
        }

        [Fact]
        public async Task GetByColorAndProduct_ReturnsNotFound_WhenNoMatchingProductSkuFound()
        {
            // Arrange
            var productId = 1;
            var colorId = 1;

            _mockProductSkuRepo.Setup(x => x.GetAll(
              It.IsAny<Expression<Func<ProductSku, bool>>>(),
              It.IsAny<Func<IQueryable<ProductSku>, IOrderedQueryable<ProductSku>>>(),
              It.IsAny<string>()))
              .ReturnsAsync((List<ProductSku>)null);

            // Act
            var result = await _productSkuController.GetByColorAndProduct(productId, colorId);

            // Assert
            var okResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateProductSku_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var requestProductSkuDto = _fixture.Create<RequestProductSkuDto>();
            var productSku = _fixture.Create<ProductSku>();
            _mockProductSkuRepo.Setup(x => x.Create(It.IsAny<ProductSku>())).Returns(Task.CompletedTask);

            // Act
            var result = await _productSkuController.CreateProductSku(requestProductSkuDto);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            // Add more detailed assertions as needed
        }

        [Fact]
        public async Task UpdateSku_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var requestProductSkuDto = _fixture.Create<RequestProductSkuDto>();
            var id = 1; // Assuming a valid ID
            var productSku = _fixture.Create<ProductSku>();

            _mockProductSkuRepo.Setup(x => x.GetById(id)).ReturnsAsync(productSku);
            _mockProductSkuRepo.Setup(x => x.Update(id, It.IsAny<ProductSku>())).ReturnsAsync(productSku);
            _mockUnitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            // Act
            var result = await _productSkuController.UpdateSku(requestProductSkuDto, id);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async Task DeleteSku_ReturnsOkResult_WithValidId()
        {
            // Arrange
            var id = 1; // Assuming a valid ID
            var productSku = _fixture.Create<ProductSku>();

            _mockProductSkuRepo.Setup(x => x.GetById(id)).ReturnsAsync(productSku);
            _mockProductSkuRepo.Setup(x => x.Delete(id)).ReturnsAsync(productSku);
            _mockUnitOfWork.Setup(x => x.Save()).Returns(Task.CompletedTask);

            // Act
            var result = await _productSkuController.DeleteSku(id);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteSku_ReturnsNotFound_WithInvalidId()
        {
            // Arrange
            var invalidId = -1; // Assuming an invalid ID

            _mockProductSkuRepo.Setup(x => x.GetById(invalidId)).ReturnsAsync((ProductSku)null);

            // Act
            var result = await _productSkuController.DeleteSku(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
