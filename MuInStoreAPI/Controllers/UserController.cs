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
	}
}
