using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuIn.Domain.Aggregates.UserAggregate;
using MuInShared.Account;
using MuInShared.User;
using MuInStoreAPI.Service;

namespace MuInStoreAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ITokenService _tokenService;
		private readonly SignInManager<AppUser> _signInManager;
		public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_tokenService = tokenService;
			_signInManager = signInManager;
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
			try
			{
				if (!ModelState.IsValid) return BadRequest(ModelState);
				//var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
				// Don't use PasswordSignInAsync because it will trigger the cookie, I dont want to reponse the cookie
				// So I will use UserManager to verify the user

				var user = await _userManager.FindByNameAsync(loginDto.Username);
				if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
				{
					return Unauthorized("User not found and/or password incorrect");
				}
				return Ok(
					new NewUserDto
					{
						UserName = user.UserName,
						UserId = user.Id,
						Email = user.Email,
						Token = _tokenService.CreateToken(user)
					}
				);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return Ok(new { Message = "Logged out successfully" });
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			try
			{
				if (!ModelState.IsValid) return BadRequest(ModelState);
				var appUser = new AppUser
				{
					UserName = registerDto.UserName,
					Email = registerDto.Email,
				};
				var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);
				if (createUser.Succeeded)
				{
					var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
					if (roleResult.Succeeded)
					{
						NewUserDto newUser = new NewUserDto
						{
							UserName = appUser.UserName,
							UserId = appUser.Id,
							Email = appUser.Email,
							Token = _tokenService.CreateToken(appUser)
						};
						return Ok(newUser);
					}
					else
					{
						return StatusCode(500, roleResult.Errors);
					}
				}
				else
				{
					return StatusCode(500, createUser.Errors);
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpGet("{userId}")]
		[Authorize]
		public IActionResult GetUserInfo(string userId)
		{
			var appUser = _userManager.Users.FirstOrDefault(x => x.Id == userId);
			UserInfoDto userInfo = new UserInfoDto
			{
				UserID = appUser.Id,
				FullName = appUser.UserName,
				Phone = appUser.PhoneNumber,
				Address = appUser.Address
			};
			return Ok(userInfo);
		}


	}
}
