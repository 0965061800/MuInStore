using Microsoft.AspNetCore.Mvc;
using MuInMVC.Extension;
using MuInMVC.Interfaces;
using MuInShared.Cart;
using MuInShared.Checkout;
using MuInShared.Order;
using Newtonsoft.Json;
using System.Text;

namespace MuInMVC.Controllers
{
	public class CheckoutController : Controller
	{
		ICartService _cartService;
		IUserService _userService;
		ICheckoutService _checkoutService;
		IOrderService _orderService;
		public CheckoutController(ICartService cartService, IUserService userService, ICheckoutService checkoutService, IOrderService orderService)
		{
			_cartService = cartService;
			_userService = userService;
			_checkoutService = checkoutService;
			_orderService = orderService;
		}

		public async Task<IActionResult> Index()
		{
			//Lay gio hang ra de xu ly
			var cart = HttpContext.Session.Get<List<AddToCartVM>>("GioHang");

			//lay thong tin nguoi dung
			var taikhoanID = HttpContext.Session.GetString("UserId");
			if (taikhoanID == null)
			{
				return RedirectToAction("Login", "Account");
			}

			var token = HttpContext.Session.GetString("JWToken");

			var userInfo = _userService.GetUserInfo(token, taikhoanID);
			if (userInfo != null)
			{
				CheckoutVM model = new CheckoutVM
				{
					UserId = userInfo.UserID,
					FullName = userInfo.FullName,
					Email = userInfo.Email,
					Phone = userInfo.Phone,
					Address = userInfo.Address,
				};

				//Lay thong tin cart
				string cartData = JsonConvert.SerializeObject(cart);
				var cartReponse = _cartService.GetCartData(cartData);
				if (cartReponse == null)
				{
					return View("Error");
				}
				ViewBag.cartItems = cartReponse;
				return View(model);
			}
			return RedirectToAction("Login", "Account");
		}

		public async Task<IActionResult> Checkout()
		{
			var cart = HttpContext.Session.Get<List<AddToCartVM>>("GioHang");
			string cartData = JsonConvert.SerializeObject(cart);
			var cartItemReponses = _cartService.GetCartData(cartData);
			var token = HttpContext.Session.GetString("JWToken");

			if (string.IsNullOrEmpty(token))
			{
				TempData["Message"] = "You need to login to comment";
				return RedirectToPage("Login");
			}
			string dataCart = JsonConvert.SerializeObject(cartItemReponses);
			bool resultCheckout = _checkoutService.CheckOut(token, dataCart);
			if (resultCheckout)
			{
				HttpContext.Session.Set<List<AddToCartVM>>("GioHang", new List<AddToCartVM>());
				return RedirectToAction("Success");
			}
			else
			{
				TempData["Message"] = "Sorry! Something wrong";
				return View();
			}
		}

		public async Task<ActionResult> Success()
		{
			var token = HttpContext.Session.GetString("JWToken");
			if (string.IsNullOrEmpty(token))
			{
				TempData["Message"] = "You need to login to comment";
				return RedirectToPage("Login");
			}
			var orders = _orderService.GetOrderByUser(token);
			if (orders == null)
			{
				return View("Error");
			}
			OrderFullDto orderSuccess = orders.OrderByDescending(x => x.CreateDate).FirstOrDefault();
			return View(orderSuccess);
		}
	}
}
