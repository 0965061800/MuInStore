using Microsoft.AspNetCore.Mvc;
using MuIn.Application.Interfaces;
using MuInShared.Cart;
using MuInShared.Checkout;
using MuInStoreAPI.Extensions;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CheckoutController : ControllerBase
	{
		private readonly ICheckoutService _checkoutService;
		public CheckoutController(ICheckoutService checkoutService)
		{
			_checkoutService = checkoutService;
		}

		[HttpPost]
		public async Task<IActionResult> Checkout([FromBody] RequestCheckout requestCheckout)
		{
			List<CartItemReponse> cart = requestCheckout.cart;
			CheckoutVM userInfo = requestCheckout.userInfo;
			try
			{
				var username = User.GetUserName();
				await _checkoutService.HandleCheckout(cart, userInfo, username);
				return Ok("Success");
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}
