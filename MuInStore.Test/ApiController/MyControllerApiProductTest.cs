using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared;
using MuInShared.Helpers;
using MuInShared.Product;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using System.Linq.Expressions;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiProductTest : SetupTest
    {
        public MyControllerApiProductTest()
        {
            // Setup for ProductController
        }

        [Fact]
        public async Task GetAllProduct_ReturnsOkResult_WithProducts()
        {
            // Arrange
            var query = new ProductQueryObject { CategoryId = 1 };
            var products = _fixture.CreateMany<Product>(5).ToList();
            _mockProductRepo.Setup(r => r.GetAll(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(), "Category,Feature,Brand"))
                            .ReturnsAsync(products);

            // Act
            var result = await _productController.GetAllProduct(query);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ReponseModel<List<ProductDto>>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var response = Assert.IsType<ReponseModel<List<ProductDto>>>(okResult.Value);
            Assert.Equal(products.Count, response.Data.Count);
        }

        [Fact]
        public async Task GetProductById_ReturnsOkResult_WithProduct()
        {
            // Arrange
            var product = _fixture.Create<Product>();
            _mockProductRepo.Setup(r => r.GetProductByIdAsync(product.ProductId)).ReturnsAsync(product);

            // Act
            var result = await _productController.GetById(product.ProductId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ProductFullDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var productDto = Assert.IsType<ProductFullDto>(okResult.Value);
            Assert.Equal(product.ProductId, productDto.ProductId);
            Assert.Equal(product.ProductName, productDto.ProductName);
        }

        [Fact]
        public async Task CreateProduct_ReturnsOkResult_WhenCreatedSuccessfully()
        {
            // Arrange
            var requestProductDto = _fixture.Create<RequestProductDto>();
            var newProduct = requestProductDto.ToProduct();
            var newProductSku = new ProductSku
            {
                ColorId = requestProductDto.ColorId,
                ProductId = newProduct.ProductId,
                UnitPrice = requestProductDto.ProductPrice,
                Sku = requestProductDto.ProductCode,
                UnitInStock = 10,
                ImageName = requestProductDto.ImageName,
                skuImage = requestProductDto.productImage
            };

            _mockProductRepo.Setup(r => r.Create(It.IsAny<Product>())).Returns(Task.CompletedTask);
            _mockProductSkuRepo.Setup(r => r.Create(It.IsAny<ProductSku>())).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(u => u.Save()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(u => u.BeginTransactionAsync()).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(u => u.CommitAsync()).Returns(Task.CompletedTask);

            _mockCategoryRepo.Setup(r => r.CheckCategoryId(It.IsAny<int>())).ReturnsAsync(true);
            _mockBrandRepo.Setup(r => r.CheckBrandId(It.IsAny<int>())).ReturnsAsync(true);
            _mockFeatureRepo.Setup(r => r.CheckFeatureId(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _productController.CreateProduct(requestProductDto);

            // Assert
            var actionResult = Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsOkResult_WhenUpdatedSuccessfully()
        {
            // Arrange
            var product = _fixture.Create<Product>();
            var updateProductDto = _fixture.Create<UpdateProductDto>();
            var updatedProduct = updateProductDto.UpdateToProduct(product);

            _mockProductRepo.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(product);
            _mockProductRepo.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<Product>())).ReturnsAsync(updatedProduct);
            _mockUnitOfWork.Setup(u => u.Save()).Returns(Task.CompletedTask);

            _mockCategoryRepo.Setup(r => r.CheckCategoryId(It.IsAny<int>())).ReturnsAsync(true);
            _mockBrandRepo.Setup(r => r.CheckBrandId(It.IsAny<int>())).ReturnsAsync(true);
            _mockFeatureRepo.Setup(r => r.CheckFeatureId(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _productController.UpdateProduct(product.ProductId, updateProductDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var productDto = Assert.IsType<ProductDto>(actionResult.Value);
            Assert.Equal(updatedProduct.ProductId, productDto.ProductId);
            Assert.Equal(updatedProduct.ProductName, productDto.ProductName);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNoContent_WhenDeletedSuccessfully()
        {
            // Arrange
            var product = _fixture.Create<Product>();
            _mockProductRepo.Setup(r => r.GetById(product.ProductId)).ReturnsAsync(product);
            _mockProductRepo.Setup(r => r.DeleteEntity(product)).ReturnsAsync(product);
            _mockUnitOfWork.Setup(u => u.Save()).Returns(Task.CompletedTask);

            // Act
            var result = await _productController.DeleteProduct(product.ProductId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteProduct_ReturnsNotFound_WhenProductNotFound()
        {
            // Arrange
            _mockProductRepo.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Product)null);

            // Act
            var result = await _productController.DeleteProduct(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}