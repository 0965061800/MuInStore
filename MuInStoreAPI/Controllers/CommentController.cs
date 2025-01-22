using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuIn.Application.Interfaces;
using MuInShared.Comment;
using MuInStoreAPI.Extensions;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CommentController : ControllerBase
	{
		private readonly ICommentServices _commentServices;
		public CommentController(ICommentServices commentServices)
		{
			_commentServices = commentServices;
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
				await _commentServices.AddCommentAsync(productId, requestCommentDto, username);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

	}
}
