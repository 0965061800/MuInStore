using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.Category;
using MuInShared.Helpers;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using System.Linq.Expressions;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiCategoryTests : SetupTest
    {

        public MyControllerApiCategoryTests()
        {
            _mockUnitOfWork.Setup(x => x.CategoryRepository).Returns(_mockCategoryRepo.Object);
        }

        [Fact]
        public async Task Get_ReutrnsOkResult_WithCategoryDto()
        {
            //Arrange

            var category = _fixture.Build<Category>().Create();

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

        [Fact]
        public async Task GetAllCategory_ReturnsOkResult_WithCategories()
        {
            // Arrange
            var categories = _fixture.CreateMany<Category>(5).ToList();
            var catQuery = new CatQueryObject { ParentId = 1 };

            _mockCategoryRepo
                .Setup(r => r.GetAll(It.IsAny<Expression<Func<Category, bool>>>(), null, "Subcategories"))
                .ReturnsAsync(categories);

            // Act
            var result = await _categoryController.GetAllCategory(catQuery);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CategoryDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var categoryDtos = Assert.IsAssignableFrom<IEnumerable<CategoryDto>>(okResult.Value);
            Assert.Equal(categories.Count, categoryDtos.Count());

            foreach (var categoryDto in categoryDtos)
            {
                var category = categories.First(c => c.CatId == categoryDto.CatId);
                Assert.Equal(category.CatId, categoryDto.CatId);
                Assert.Equal(category.CatName, categoryDto.CatName);
            }
        }

        [Fact]
        public async Task GetAllCategory_ReturnsNotFound_WhenNoCategories()
        {
            // Arrange
            var catQuery = new CatQueryObject { ParentId = 1 };
            _mockCategoryRepo.Setup(r => r.GetAll(It.IsAny<Expression<Func<Category, bool>>>(), null, "Subcategories"))
                             .ReturnsAsync((IEnumerable<Category>)null);

            // Act
            var result = await _categoryController.GetAllCategory(catQuery);

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CategoryDto>>>(result);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            Assert.Equal("There is no category in your database", notFoundResult.Value);
        }

        [Fact]
        public async Task CreateCategory_ReturnsOkResult_WhenCategoryCreated()
        {
            // Arrange
            var requestCatDto = _fixture.Build<RequestCatDto>().Create();
            var category = requestCatDto.ToCategoryFromRequest();
            _mockCategoryRepo.Setup(r => r.Create(It.IsAny<Category>())).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(u => u.Save()).Returns(Task.CompletedTask);

            // Act
            var result = await _categoryController.CreateCategory(requestCatDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var categoryDto = Assert.IsType<CategoryDto>(actionResult.Value);
            Assert.Equal(category.CatName, categoryDto.CatName);
        }

        [Fact]
        public async Task CreateCategory_ReturnsBadRequest_WhenModelStateInvalid()
        {
            // Arrange
            _categoryController.ModelState.AddModelError("Name", "Required");
            var requestCatDto = _fixture.Build<RequestCatDto>().Create();

            // Act
            var result = await _categoryController.CreateCategory(requestCatDto);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(actionResult.Value);
        }

        [Fact]
        public async Task CreateCategory_ReturnsBadRequest_WhenExceptionThrown()
        {
            // Arrange
            var exceptionMessage = "Test exception";
            var requestCatDto = _fixture.Build<RequestCatDto>().Create();
            _mockCategoryRepo.Setup(r => r.Create(It.IsAny<Category>())).ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _categoryController.CreateCategory(requestCatDto);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(exceptionMessage, actionResult.Value);
        }

        [Fact]
        public async Task UpdateCategory_ReturnsOkResult_WhenUpdatedSuccessfully()
        {
            // Arrange
            var category = _fixture.Build<Category>().Create();
            var requestCatDto = _fixture.Build<RequestCatDto>().Create();
            var updatedCategory = requestCatDto.ToUpdateCategory(category);

            _mockCategoryRepo.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(category);
            _mockCategoryRepo.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<Category>())).ReturnsAsync(updatedCategory);
            _mockUnitOfWork.Setup(u => u.Save()).Returns(Task.CompletedTask);

            // Act
            var result = await _categoryController.UpdateCategory(category.CatId, requestCatDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var categoryDto = Assert.IsType<CategoryDto>(actionResult.Value);
            Assert.Equal(updatedCategory.CatId, categoryDto.CatId);
            Assert.Equal(updatedCategory.CatName, categoryDto.CatName);
        }

        [Fact]
        public async Task UpdateCategory_ReturnsBadRequest_WhenModelStateInvalid()
        {
            // Arrange
            _categoryController.ModelState.AddModelError("Name", "Required");
            var requestCatDto = _fixture.Build<RequestCatDto>().Create();

            // Act
            var result = await _categoryController.UpdateCategory(1, requestCatDto);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(actionResult.Value);
        }

        [Fact]
        public async Task UpdateCategory_ReturnsNotFound_WhenCategoryNotExists()
        {
            // Arrange
            _mockCategoryRepo.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Category)null);
            var requestCatDto = _fixture.Build<RequestCatDto>().Create();

            // Act
            var result = await _categoryController.UpdateCategory(1, requestCatDto);

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("No Category Found", actionResult.Value);
        }

        [Fact]
        public async Task UpdateCategory_ReturnsStatusCode500_WhenExceptionThrown()
        {
            // Arrange
            var exceptionMessage = "Test exception";
            var category = _fixture.Build<Category>().Create();
            var requestCatDto = _fixture.Build<RequestCatDto>().Create();
            _mockCategoryRepo.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(category);
            _mockCategoryRepo.Setup(r => r.Update(It.IsAny<int>(), It.IsAny<Category>())).ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _categoryController.UpdateCategory(category.CatId, requestCatDto);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, actionResult.StatusCode);
            Assert.Equal(exceptionMessage, actionResult.Value);
        }
    }
}
