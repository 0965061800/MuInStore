using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuInShared.Brands;
using MuInShared.Helpers;
using Newtonsoft.Json;

namespace MuInMVC.Controllers.Components
{
	public class QueryProduct : ViewComponent
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public QueryProduct()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public IViewComponentResult Invoke()
		{
			ProductQueryObject query = new ProductQueryObject();
			List<BrandDto> brands = new();
			HttpResponseMessage brandReponse = _httpClient.GetAsync(_httpClient.BaseAddress + "/Brand").Result;
			if (brandReponse.IsSuccessStatusCode)
			{
				string brandData = brandReponse.Content.ReadAsStringAsync().Result;
				brands = JsonConvert.DeserializeObject<List<BrandDto>>(brandData);
			}
			ViewBag.BrandList = new SelectList(brands.Select(b => new { BrandId = b.BrandId, Name = b.BrandName }), "BrandId", "Name");
			return View(query);
		}
	}
}
