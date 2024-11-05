using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MuInShared.Comment;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MuInStore.Test.ApiController
{
    public class MyControllerApiCommentTest : SetupTest
    {
        [Fact]
        public async Task GetAllComments_ReturnsOkResult_WithComments()
        {
            // Arrange
            var comments = _fixture.CreateMany<Comment>().ToList();
            _mockCommentRepo.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Comment, bool>>>(), null, ""))
                .ReturnsAsync(comments);

            // Act
            var result = await _commentController.GetAllComments();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CommentDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnComments = Assert.IsType<List<CommentDto>>(okResult.Value);
            Assert.Equal(comments.Count, returnComments.Count);
        }

        [Fact]
        public async Task GetAllComments_ReturnsBadRequest_WhenNoComments()
        {
            // Arrange
            _mockCommentRepo.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Comment, bool>>>(), null, ""))
                .ReturnsAsync((IEnumerable<Comment>)null);

            // Act
            var result = await _commentController.GetAllComments();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CommentDto>>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.Equal("No comment for you", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateComment_ReturnsOkResult_WithValidComment()
        {
            // Arrange
            var requestCommentDto = _fixture.Create<RequestCommentDto>();
            var appUser = _fixture.Create<AppUser>();
            var comment = requestCommentDto.ToCommnetFromRequest();
            comment.AppUser = appUser;
            comment.AppUserId = appUser.Id;

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.GivenName, appUser.UserName)
            }, "mock"));

            _commentController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            _mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(appUser);

            _mockCommentRepo.Setup(repo => repo.Create(It.IsAny<Comment>())).Callback<Comment>(c => c.AppUser = appUser).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(uow => uow.Save()).Returns(Task.CompletedTask);

            // Act
            var result = await _commentController.CreateComment(1, requestCommentDto);

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnComment = Assert.IsType<CommentDto>(okResult.Value);
            Assert.Equal(requestCommentDto.Content, returnComment.Content);
        }

        [Fact]
        public async Task CreateComment_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _commentController.ModelState.AddModelError("Content", "Required");

            // Act
            var result = await _commentController.CreateComment(1, new RequestCommentDto());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        //[Fact]
        //public async Task CreateComment_ReturnsStatusCode500_WhenExceptionIsThrown()
        //{
        //    // Arrange
        //    var requestCommentDto = _fixture.Create<RequestCommentDto>();
        //    var appUser = _fixture.Create<AppUser>();
        //    var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        //    {
        //        new Claim(ClaimTypes.Name, appUser.UserName)
        //    }, "mock"));

        //    _commentController.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = new DefaultHttpContext { User = user }
        //    };

        //    _mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(appUser);

        //    _mockCommentRepo.Setup(repo => repo.Create(It.IsAny<Comment>())).ThrowsAsync(new Exception("Database error"));

        //    // Act
        //    var result = await _commentController.CreateComment(1, requestCommentDto);

        //    // Assert
        //    var statusCodeResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(500, statusCodeResult.StatusCode);
        //    Assert.Equal("Database error", statusCodeResult.Value);
        //}
    }
}
