using Microsoft.AspNetCore.Mvc;
using MuInShared.ProductSku;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;
using System.Linq.Expressions;

namespace MuInStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSkuController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public ProductSkuController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductSkuFullDto>> GetById(int id)
        {

            var productSku = await _uow.ProductSkuRepository.GetById(id);
            if (productSku == null)
            {
                return NotFound("");
            }
            var productSkuDto = productSku.ToProductSkuFullDto();
            return Ok(productSkuDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetByColorAndProduct(int? ProductId, int? ColorId)
        {
            Expression<Func<ProductSku, bool>> filter = p => (ProductId == 0 || p.ProductId == ProductId) && (ColorId == 0 || p.ColorId == ColorId);
            var productSku = await _uow.ProductSkuRepository.GetAll(filter, includeProperties: "Color");
            if (productSku == null)
            {
                return NotFound();
            }
            ProductSkuDto productSkuDto = productSku.FirstOrDefault().ToProductSkuDto();
            return Ok(productSkuDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductSku([FromBody] RequestProductSkuDto requestproductSkudto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ProductSku newProductSku = requestproductSkudto.ToProductSku();
            try
            {
                await _uow.ProductSkuRepository.Create(newProductSku);
                await _uow.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSku([FromBody] RequestProductSkuDto requestProductSkuDto, int id)
        {
            var productSkuDto = await _uow.ProductSkuRepository.GetById(id);
            if (productSkuDto == null)
            {
                return NotFound("There is no productSku in your database");
            }
            productSkuDto = requestProductSkuDto.ToUpdateProductSku(productSkuDto);
            try
            {
                await _uow.ProductSkuRepository.Update(id, productSkuDto);
                await _uow.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSku(int id)
        {
            try
            {
                var productSku = await _uow.ProductSkuRepository.GetById(id);
                if (productSku == null)
                {
                    return NotFound();
                }
                await _uow.ProductSkuRepository.Delete(id);
                await _uow.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
