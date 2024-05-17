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
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
        {
            var brands = await _uow.BrandRepository.GetAll();
            if (brands == null)
            {
                return NotFound("No Brand in your database");
            }
            var brandDtos = brands.Select(x => x.ToBrandDto());
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
        [HttpPost]
        public async Task<IActionResult> CreateBrand(RequestBrandDto requestBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Brand brand = requestBrandDto.ToBrandFromRequest();
            try
            {
                await _uow.BrandRepository.Create(brand);
                await _uow.Save();
                return Ok(brand.ToBrandDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, RequestBrandDto requestBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var brand = await _uow.BrandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound("No Category Found");
            }
            brand = requestBrandDto.ToUpdateBrand(brand);
            try
            {
                await _uow.BrandRepository.Update(id, brand);
                await _uow.Save();
                return Ok(brand.ToBrandDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _uow.BrandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound("No Brand Found");
            }
            try
            {
                await _uow.BrandRepository.Delete(id);
                await _uow.Save();
                return Ok($"Delete Category {brand.BrandName} successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
