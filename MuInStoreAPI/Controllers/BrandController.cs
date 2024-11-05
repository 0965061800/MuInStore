using Microsoft.AspNetCore.Mvc;
using MuInShared.Brands;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;

namespace MuInStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public BrandController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<ActionResult<List<BrandDto>>> GetAllBrands()
        {
            var brands = await _uow.BrandRepository.GetAll();
            if (brands == null)
            {
                return NotFound("No Brand in your database");
            }
            var brandDtos = brands.Select(x => x.ToBrandDto()).ToList();
            return Ok(brandDtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {
            var brand = await _uow.BrandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound("No brand found");
            }
            BrandDto brandDto = brand.ToBrandDto();
            return Ok(brandDto);
        }

    }
}
