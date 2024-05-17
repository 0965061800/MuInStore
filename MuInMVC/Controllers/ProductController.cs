using Microsoft.AspNetCore.Mvc;
using MuInShared;
using MuInShared.Category;
using MuInShared.Product;
using Newtonsoft.Json;

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
		public IActionResult CategoryProductList(int id)
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
	}
}