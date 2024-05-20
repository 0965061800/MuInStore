using Microsoft.AspNetCore.Mvc;
using MuInMVC.Extension;
using MuInShared.Cart;
using Newtonsoft.Json;
using System.Text;

namespace MuInMVC.Controllers
{
	public class CartController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public CartController()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}
		public List<AddToCartVM> GioHang
		{
			get
			{
				var gh = HttpContext.Session.Get<List<AddToCartVM>>("GioHang");
				if (gh == default(List<AddToCartVM>))
				{
					gh = new List<AddToCartVM>();
				}
				return gh;
			}
		}

		[HttpPost]
		public IActionResult AddToCart(AddToCartVM addToCartVM)
		{
			if (ModelState.IsValid)
			{
				List<AddToCartVM> cart = GioHang;
				try
				{
					AddToCartVM item = cart.SingleOrDefault(c => c.ProductId == addToCartVM.ProductId && c.ColorId == addToCartVM.ColorId);
					if (item != null)
					{
						item.Quantity = item.Quantity + addToCartVM.Quantity;
						HttpContext.Session.Set<List<AddToCartVM>>("GioHang", cart);
					}
					else
					{
						item = new AddToCartVM
						{
							ColorId = addToCartVM.ColorId,
							Quantity = addToCartVM.Quantity,
							ProductId = addToCartVM.ProductId,
						};
						cart.Add(item);
					}
					HttpContext.Session.Set<List<AddToCartVM>>("GioHang", cart);
					return Json(new { success = true });

				}
				catch (Exception ex)
				{
					return Json(new { success = false });
				}
			}
			else
			{
				return Json(new { success = false });
			}
		}

		public async Task<IActionResult> Index()
		{
			List<AddToCartVM> cart = GioHang;
			List<CartItemReponse> cartItemReponses = new List<CartItemReponse>();
			if (cart == null || cart.Count == 0)
			{
				ViewBag.Message = "No Cart";
				return View();
			}
			using (var client = new HttpClient())
			{
				string data = JsonConvert.SerializeObject(cart);
				StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
				HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Cart", content).Result;
				if (response.IsSuccessStatusCode)
				{
					string result = response.Content.ReadAsStringAsync().Result;
					cartItemReponses = JsonConvert.DeserializeObject<List<CartItemReponse>>(result);
					return View(cartItemReponses);
				}
				else
				{
					return View();
				}
			}
		}
	}
}
