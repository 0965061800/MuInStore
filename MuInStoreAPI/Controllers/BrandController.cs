using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuIn.Application.Interfaces;
using MuInShared.Brands;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BrandController : ControllerBase
	{
		private IBrandServices _brandService;
		private IMapper _mapper;
		public BrandController(IBrandServices brandServices, IMapper mapper)
		{
			_brandService = brandServices;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<List<BrandDto>>> GetAllBrands()
		{
			var brands = await _brandService.GetAllBrand();
			if (brands == null)
			{
				return NotFound("No Brand in your database");
			}
			var brandDtos = brands.Select(x => _mapper.Map<BrandDto>(x)).ToList();
			return Ok(brandDtos);
		}
		//[HttpGet("{id}")]
		//public async Task<ActionResult<Brand>> GetBrandById(int id)
		//{
		//	var brand = await _uow.BrandRepository.GetById(id);
		//	if (brand == null)
		//	{
		//		return NotFound("No brand found");
		//	}
		//	BrandDto brandDto = brand.ToBrandDto();
		//	return Ok(brandDto);
		//}

	}
}
