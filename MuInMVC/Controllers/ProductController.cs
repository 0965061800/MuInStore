using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuInMVC.Helpers;
using MuInShared;
using MuInShared.Cart;
using MuInShared.Category;
using MuInShared.Comment;
using MuInShared.Helpers;
using MuInShared.Product;
using MuInShared.ProductSku;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MuInMVC.Controllers
{
	public class ProductController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public ProductController()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public IActionResult Index()
		{
			ReponseModel<List<ProductDto>> productList = new();
			List<CategoryDto> categoryList = new();

			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Product").Result;
			HttpResponseMessage catResponse = _httpClient.GetAsync(_httpClient.BaseAddress + "/Category").Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				productList = JsonConvert.DeserializeObject<ReponseModel<List<ProductDto>>>(data);

				string catData = catResponse.Content.ReadAsStringAsync().Result;
				categoryList = JsonConvert.DeserializeObject<List<CategoryDto>>(catData);
			}
			ViewData["Categories"] = categoryList;
			return View(productList.Data);
		}


		public IActionResult ProductDetail(int id)
		{
			ProductFullDto productFullDto = new ProductFullDto();
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Product/" + id).Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				productFullDto = JsonConvert.DeserializeObject<ProductFullDto>(data);
			}
			ViewBag.ProductName = productFullDto.ProductName;

			if (productFullDto.ProductSkuDtos != null)
			{
				var colors = new SelectList(productFullDto.ProductSkuDtos
					.Where(p => p.ColorDto != null) // Ensure ColorDto is not null
					.Select(p => new { p.ColorDtoId, Name = p.ColorDto.ColorName }), "ColorDtoId", "Name");

				ViewData["Colors"] = colors;
			}

			AddToCartVM addToCart = new AddToCartVM
			{
				ProductId = productFullDto.ProductId,
			};

			ViewBag.AddToCart = addToCart;
			RequestCommentDto commentDto = new RequestCommentDto();
			ViewBag.RequestCommentDto = commentDto;

			return View(productFullDto);
		}

		public async Task<IActionResult> CreateCommentAsync(int productId, RequestCommentDto requestCommentDto)
		{
			if (!ModelState.IsValid)
			{
				var message = string.Join(" | ", ModelState.Values
			   .SelectMany(v => v.Errors)
			   .Select(e => e.ErrorMessage));
				TempData["Message"] = message;
				return RedirectToAction("ProductDetail", new { id = productId });
			}
			var token = HttpContext.Session.GetString("JWToken");

			if (string.IsNullOrEmpty(token))
			{
				TempData["Message"] = "You need to login to comment";
				return RedirectToAction("ProductDetail", new { id = productId });
			}
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			string data = JsonConvert.SerializeObject(requestCommentDto);
			StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
			HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Comment/" + productId, content).Result;
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductDetail", new { id = productId });
			}
			else
			{
				TempData["Message"] = await response.Content.ReadAsStringAsync();
				return RedirectToAction("ProductDetail", new { id = productId });
			}
		}

		[HttpPost]
		public IActionResult Filter(ProductQueryObject query)
		{
			ReponseModel<List<ProductDto>> productList = new();
			List<CategoryDto> categoryList = new();

			var queryString = QueryStringHelper.ToQueryString(query);

			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Product" + queryString).Result;

			HttpResponseMessage catResponse = _httpClient.GetAsync(_httpClient.BaseAddress + "/Category").Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				productList = JsonConvert.DeserializeObject<ReponseModel<List<ProductDto>>>(data);

				string catData = catResponse.Content.ReadAsStringAsync().Result;
				categoryList = JsonConvert.DeserializeObject<List<CategoryDto>>(catData);
			}
			ViewData["Categories"] = categoryList;
			return View("Index", productList.Data);
		}

		public async Task<IActionResult> ChangeColor(int? productId, int? colorId)
		{
			ProductSkuDto productSkuDto = new ProductSkuDto();
			var data = new
			{
				ProductId = productId,
				ColorId = colorId,
			};

			var queryString = QueryStringHelper.ToQueryString(data);
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/ProductSku" + queryString).Result;

			if (response.IsSuccessStatusCode)
			{
				string result = response.Content.ReadAsStringAsync().Result;
				productSkuDto = JsonConvert.DeserializeObject<ProductSkuDto>(result);
			}
			return Json(productSkuDto);
		}
	}
}