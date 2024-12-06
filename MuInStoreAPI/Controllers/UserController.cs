using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuIn.Domain.Aggregates.UserAggregate;
using MuInShared.User;
using MuInStoreAPI.Mappers;

namespace MuInStoreAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		public UserController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<ActionResult<List<UserDto>>> GetAllAppUser()
		{
			List<AppUser> users = _userManager.Users.ToList();
			if (users == null || users.Count == 0)
			{
				return NotFound("No User in your database");
			}
			List<UserDto> usersDtos = users.Select(x => x.ToUserDto()).ToList();
			return Ok(usersDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppUser(string id)
		{
			AppUser user = _userManager.Users.Where(x => x.Id == id).Include(x => x.Orders).ThenInclude(o => o.Payment).ThenInclude(p => p.PayStatus).FirstOrDefault();
			if (user == null)
			{
				NotFound("No found user");
			}
			UserFullDto userFullDto = user.ToUserFullDto();
			return Ok(userFullDto);
		}
	}
}
