using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuInShared.Comment;
using MuInStoreAPI.Extensions;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;

namespace MuInStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(IUnitOfWork uow, UserManager<AppUser> userManager)
        {
            _uow = uow;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAllComments()
        {
            var comments = await _uow.CommentRepository.GetAll();

            if (comments == null)
            {
                return BadRequest("No comment for you");
            }
            var commentDtos = comments.Select(x => x.ToCommentDto()).ToList();
            return Ok(commentDtos);
        }

        [HttpPost("{productId}")]
        [Authorize]
        public async Task<IActionResult> CreateComment(int productId, RequestCommentDto requestCommentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var username = User.GetUserName();
                var appUser = await _userManager.FindByNameAsync(username);
                Comment comment = requestCommentDto.ToCommnetFromRequest();
                comment.AppUserId = appUser.Id;
                comment.ProductId = productId;
                await _uow.CommentRepository.Create(comment);
                await _uow.Save();
                return Ok(comment.ToCommentDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
