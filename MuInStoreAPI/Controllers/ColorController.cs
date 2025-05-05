using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuIn.Application.Interfaces;
using MuInShared.Color;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ColorController : ControllerBase
	{
		private readonly IColorService _colorSerivice;
		private readonly IMapper _mapper;
		public ColorController(IColorService colorService, IMapper mapper)
		{
			_colorSerivice = colorService;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ColorDto>>> GetAllColors()
		{
			var colors = await _colorSerivice.ListAllColors();
			if (colors == null)
			{
				return NotFound("No Color in your database");
			}
			var ColorDtos = colors.Select(x => _mapper.Map<ColorDto>(x)).ToList();
			return Ok(colors);
		}
	}
}
