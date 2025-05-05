using Microsoft.AspNetCore.Mvc;
using MuIn.Application.Interfaces;
using MuInShared.Cart;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CartController : ControllerBase
	{
		private readonly IProductServices _productService;
		public CartController(IProductServices productService)
		{
			_productService = productService;
		}
		[HttpPost]
		public async Task<IActionResult> GetCartDetail([FromBody] List<AddToCartVM> cartItems)
		{
			var cartItemReponse = await _productService.GetCartItemInfo(cartItems);
			return Ok(cartItemReponse);
		}

	}
}
