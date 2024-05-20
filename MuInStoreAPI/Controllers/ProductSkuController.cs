using Microsoft.AspNetCore.Mvc;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;

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
		public async Task<ActionResult<ProductSku>> GetById(int id)
		{

			var productSku = await _uow.ProductSkuRepository.GetById(id);
			if (productSku == null)
			{
				return NotFound("");
			}
			var productSkuDto = productSku.ToProductSkuFullDto();
			return Ok(productSkuDto);
		}
	}
}
