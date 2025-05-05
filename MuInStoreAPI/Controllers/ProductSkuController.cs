using Microsoft.AspNetCore.Mvc;
using MuIn.Application.Interfaces;
using MuInShared.ProductSku;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductSkuController : ControllerBase
	{
		private readonly IProductSkuServices _productSkuServices;
		public ProductSkuController(IProductSkuServices productSkuServices)
		{
			_productSkuServices = productSkuServices;
		}

		[HttpGet]
		public async Task<IActionResult> GetByColorAndProduct([FromQuery] int productId, int colorId)
		{
			ProductSkuDto productSkuDto = await _productSkuServices.GetProductSku(productId, colorId);
			return Ok(productSkuDto);
		}

		[HttpPost]
		public async Task<ActionResult> CreateProductSku([FromBody] RequestProductSkuDto requestproductSkudto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			try
			{
				await _productSkuServices.CreateProductSku(requestproductSkudto);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSku([FromBody] RequestProductSkuDto requestProductSkuDto)
		{
			try
			{
				await _productSkuServices.UpdateProductSku(requestProductSkuDto);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteSku([FromQuery] int productId, int colorId)
		{
			try
			{
				await _productSkuServices.DeleteProductSku(productId, colorId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
