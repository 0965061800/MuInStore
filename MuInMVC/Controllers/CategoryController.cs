using Microsoft.AspNetCore.Mvc;
using MuInMVC.Interfaces;

namespace MuInMVC.Controllers
{
	public class CategoryController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
			_categoryService = categoryService;
		}

		public IActionResult Index(int id)
		{
			var categoryFullDto = _categoryService.GetCategoryFull(id);
			if (categoryFullDto == null)
			{
				return View("Error");
			}
			ViewBag.CatName = categoryFullDto.CatName;
			ViewData["Categories"] = categoryFullDto.SubCategories;
			return View(categoryFullDto.AllProducts);
		}

		//[HttpPost]
		//public IActionResult Filter(ProductQueryObject query)
		//{
		//	ReponseModel<List<ProductDto>> productList = new();
		//	List<CategoryDto> categoryList = new();

		//	var queryString = QueryStringHelper.ToQueryString(query);

		//	HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Product" + queryString).Result;

		//	HttpResponseMessage catResponse = _httpClient.GetAsync(_httpClient.BaseAddress + "/Category").Result;

		//	if (response.IsSuccessStatusCode)
		//	{
		//		string data = response.Content.ReadAsStringAsync().Result;
		//		productList = JsonConvert.DeserializeObject<ReponseModel<List<ProductDto>>>(data);

		//		string catData = catResponse.Content.ReadAsStringAsync().Result;
		//		categoryList = JsonConvert.DeserializeObject<List<CategoryDto>>(catData);
		//	}
		//	ViewData["Categories"] = categoryList;
		//	return View("Index", productList.Data);
		//}

	}
}
