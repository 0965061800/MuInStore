using AutoFixture;
using Moq;
using MuIn.Application.Dtos;
using MuIn.Domain.Aggregates.ProductAggregate;
using MuInShared.Product;

namespace MuInStore.Test.ApplicationTesting
{
	public class ProductTesting : NewSetupTest
	{
		public ProductTesting() : base() { }
		[Fact]
		public async Task AddProduct_Success_ReturnProductDto()
		{
			//Arrange
			RequestProductDto request = _fixture.Create<RequestProductDto>();
			int colorId = 1;
			string imageName = "test.jpg";
			var product = _fixture.Create<Product>();

			product.CategoryId = 1;
			product.BrandId = 1;
			var productDto = _fixture.Create<ProductDto>();

			_mockMapper.Setup(m => m.Map<Product>(request)).Returns(product);
			_mockMapper.Setup(m => m.Map<ProductDto>(product)).Returns(productDto);

			_mockBrandRepo.Setup(r => r.CheckBrandExist((int)product.BrandId)).ReturnsAsync(true);//If the method return Task => using Return Async
			_mockCategoryRepo.Setup(r => r.CheckCatExist((int)product.CategoryId)).ReturnsAsync(true);
			_mockProductRepo.Setup(r => r.CreateAsync(product)).ReturnsAsync(product);
			_mockProductRepo.Setup(r => r.SaveChange()).Returns(Task.CompletedTask);// If the method return Task void => usign Returns(Task.CompletedTask)

			//Act
			var result = await _listProductService.Add(request, colorId, imageName);

			//Assert
			Assert.NotNull(result); //Test if the result is not null
			Assert.IsType<ProductDto>(result);// Compare the result type of result
			Assert.Equal(productDto, result);//Compare the actual result with the expected result
		}
	}
}