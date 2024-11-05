using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.Color;
using MuInStoreAPI.Models;
using System.Linq.Expressions;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiColorTest : SetupTest
    {
        [Fact]
        public async Task GetAllColor_ReturnOkObject()
        {
            //Arrage
            var colors = _fixture.CreateMany<Color>(3).ToList();
            _mockColorRepo.Setup(r => r.GetAll(It.IsAny<Expression<Func<Color, bool>>>(), null, "")).ReturnsAsync(colors);
            //Act
            var result = _colorController.GetAllColors();
            //Assert
            var resultType = Assert.IsType<Task<ActionResult<IEnumerable<ColorDto>>>>(result);
        }
    }
}
