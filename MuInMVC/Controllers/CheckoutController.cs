using Microsoft.AspNetCore.Mvc;
using MuInMVC.Extension;
using MuInShared.Cart;
using MuInShared.Checkout;
using MuInShared.User;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MuInMVC.Controllers
{
	public class CheckoutController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public CheckoutController()
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

		public async Task<IActionResult> Index(string returnUrl = null)
		{
			//Lay gio hang ra de xu ly
			var cart = HttpContext.Session.Get<List<AddToCartVM>>("GioHang");
			List<CartItemReponse> cartItemReponses = new List<CartItemReponse>();

			//lay thong tin nguoi dung
			var taikhoanID = HttpContext.Session.GetString("UserId");
			if (taikhoanID == null)
			{
				return RedirectToAction("Login", "Account");
			}

			var token = HttpContext.Session.GetString("JWToken");
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Account/" + taikhoanID).Result;
			UserInfoDto userInfo = new UserInfoDto();

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				userInfo = JsonConvert.DeserializeObject<UserInfoDto>(data);
				CheckoutVM model = new CheckoutVM
				{
					UserId = userInfo.UserID,
					FullName = userInfo.FullName,
					Email = userInfo.Email,
					Phone = userInfo.Phone,
					Address = userInfo.Address,
				};

				//Lay thong tin cart
				using (var client = new HttpClient())
				{
					string cartData = JsonConvert.SerializeObject(cart);
					StringContent content = new StringContent(cartData, Encoding.UTF8, "application/json");
					HttpResponseMessage cartResponse = _httpClient.PostAsync(_httpClient.BaseAddress + "/Cart", content).Result;
					if (cartResponse.IsSuccessStatusCode)
					{
						string result = cartResponse.Content.ReadAsStringAsync().Result;
						cartItemReponses = JsonConvert.DeserializeObject<List<CartItemReponse>>(result);
					}
					ViewBag.cartItems = cartItemReponses;
				}
				return View(model);
			}
			else
			{
				return RedirectToAction("Login", "Account");
			}
			//ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Levels == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");
		}


	}
}
