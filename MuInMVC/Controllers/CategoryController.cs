using Microsoft.AspNetCore.Mvc;
using MuInMVC.Helpers;
using MuInShared;
using MuInShared.Category;
using MuInShared.Helpers;
using MuInShared.Product;
using Newtonsoft.Json;

namespace MuInMVC.Controllers
{
	public class CategoryController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public CategoryController()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public IActionResult Index(int id)
		{
			CategoryFullDto categoryFullDto = new CategoryFullDto();
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Category/" + id).Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				categoryFullDto = JsonConvert.DeserializeObject<CategoryFullDto>(data);
			}
			ViewBag.CatName = categoryFullDto.CatName;
			ViewData["Categories"] = categoryFullDto.SubCategories;
			return View(categoryFullDto.AllProducts);
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

	}
}
