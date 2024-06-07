using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.Brands;
using MuInStoreAPI.Models;
using System.Linq.Expressions;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiBrandTest : SetupTest
    {
        [Fact]
        public async Task GetAllBrands_ReturnsOkResult_WithBrands()
        {
            // Arrange
            var brands = _fixture.CreateMany<Brand>().ToList();
            _mockBrandRepo.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Brand, bool>>>(), null, "")).ReturnsAsync(brands);

            // Act
            var result = await _brandController.GetAllBrands();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnBrands = Assert.IsType<List<BrandDto>>(okResult.Value);
            Assert.Equal(brands.Count, returnBrands.Count);
        }

        [Fact]
        public async Task GetAllBrands_ReturnsNotFoundResult_WhenNoBrandsFound()
        {
            //Arrange
            _mockBrandRepo.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Brand, bool>>>(), null, "")).ReturnsAsync((List<Brand>)null);

            // Act
            var result = await _brandController.GetAllBrands();

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("No Brand in your database", notFoundResult.Value);
        }

        [Fact]
        public async Task GetBrandById_ReturnsOkResult_WithBrand()
        {
            //Arrange
            var brand = _fixture.Create<Brand>();
            _mockBrandRepo.Setup(repo => repo.GetById(brand.BrandId)).ReturnsAsync(brand);

            //Act
            var result = await _brandController.GetBrandById(brand.BrandId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnBrand = Assert.IsType<BrandDto>(okResult.Value);
            Assert.Equal(brand.BrandId, returnBrand.BrandId);
        }

        [Fact]
        public async Task GetBrandById_ReturnsNotFoundResult_WhenBrandNotFound()
        {
            //Arrange
            _mockBrandRepo.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Brand)null);

            //Act
            var result = await _brandController.GetBrandById(1);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("No brand found", notFoundResult.Value);
        }
    }
}
