using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuInShared.Account;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
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
				var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);
				if (appUser == null) return Unauthorized("Invalid UserName!");
				var result = await _signInManager.CheckPasswordSignInAsync(appUser, loginDto.Password, false);
				if (!result.Succeeded)
				{
					return Unauthorized("User not found and/or password incorrect");
				}
				return Ok(
					new NewUserDto
					{
						UserName = appUser.UserName,
						UserId = appUser.Id,
						Email = appUser.Email,
						Token = _tokenService.CreateToken(appUser)
					}
				);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
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
		public async Task<IActionResult> GetUserInfo(string userId)
		{
			var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
			return Ok(appUser.ToUserInfoDto());
		}


	}
}
