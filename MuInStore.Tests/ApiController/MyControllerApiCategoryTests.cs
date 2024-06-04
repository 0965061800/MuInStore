using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.Category;
using MuInStoreAPI.Controllers;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;
using MuInStoreAPI.UnitOfWork;

namespace MuInStore.Tests.ApiController
{
	public class MyControllerApiCategoryTests
	{
		private readonly CategoryController _categoryController;
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly Mock<ICategoryRepository> _mockCategoryRepo;

		public MyControllerApiCategoryTests()
		{
			_mockCategoryRepo = new Mock<ICategoryRepository>();
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_mockUnitOfWork.Setup(x => x.CategoryRepository).Returns(_mockCategoryRepo.Object);
			_categoryController = new CategoryController(_mockUnitOfWork.Object);
		}




		[Fact]
		public async Task Get_ReutrnsOkResult_WithCategoryDto()
		{
			//Arrange
			var category = new Category
			{
				CatId = 1,
				CatName = "Test Category",
				Alias = "",
				CatImage = "",
				ImageName = "",
				Description = "",
				ParentCatId = 3,
				Subcategories = new List<Category>()
			};
			_mockCategoryRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(category);

			//Act
			var result = await _categoryController.GetCategoryById(1);

			//Assert
			var actionResult = Assert.IsType<ActionResult<CategoryFullDto>>(result);
			var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
			var categoryDto = Assert.IsType<CategoryFullDto>(okResult.Value);
			Assert.Equal(category.CatId, categoryDto.CatId);
			Assert.Equal(category.CatName, categoryDto.CatName);
		}

		[Fact]
		public async Task Get_ReturnsNotFound_WhenCategoryNotExits()
		{
			//Arrange
			_mockCategoryRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Category)null);
			//Act
			var result = await _categoryController.GetCategoryById(1);
			//Assert
			var actionResult = Assert.IsType<ActionResult<CategoryFullDto>>(result);
			var okResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
		}

		[Fact]
		public async Task Delete_ReturnsNotFOund_WhenCategoryNotExitst()
		{
			//Arrange
			_mockCategoryRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Category)null);
			//Act
			var result = await _categoryController.DeleteCategory(1);
			//Assert
			var actionResult = Assert.IsType<NotFoundObjectResult>(result);
			Assert.Equal("No Category Found", actionResult.Value);
		}

		[Fact]
		public async Task Delete_ReturnCode500_WhenDeleteFail()
		{
			//Arrange
			var exceptionMessage = "Test exception";
			Category cat = new Category
			{
				CatId = 2,
				CatName = "Test case"
			};
			_mockCategoryRepo.Setup(r => r.GetById(2)).ReturnsAsync(cat);
			_mockCategoryRepo.Setup(r => r.Delete(2)).ThrowsAsync(new Exception(exceptionMessage));
			//Act
			var result = await _categoryController.DeleteCategory(2);
			//Assert
			var actionResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(500, actionResult.StatusCode);
			Assert.Equal(exceptionMessage, actionResult.Value);
		}

		[Fact]
		public async Task Delete_ReturnOkResult_WhenDeleteSuccessfully()
		{
			//Arrage
			Category cat = new Category
			{
				CatId = 1,
				CatName = "Test case"
			};
			_mockCategoryRepo.Setup(r => r.GetById(1)).ReturnsAsync(cat);
			//Act
			var result = await _categoryController.DeleteCategory(1);
			//Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
		}
	}
}
