using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuInShared.User;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;

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
		public async Task<ActionResult<IEnumerable<AppUser>>> GetAllAppUser()
		{
			var users = await _userManager.Users.ToListAsync();
			if (users == null)
			{
				return NotFound("No User in your database");
			}
			List<UserDto> usersDtos = users.Select(x => x.ToUserDto()).ToList();
			return Ok(usersDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAppUser(string id)
		{
			var user = await _userManager.Users.Where(x => x.Id == id).Include(x => x.Orders).ThenInclude(o => o.Payment).ThenInclude(p => p.PayStatus).FirstOrDefaultAsync();
			if (user == null)
			{
				NotFound("No found user");
			}
			UserFullDto userFullDto = user.ToUserFullDto();
			return Ok(userFullDto);
		}
	}
}
