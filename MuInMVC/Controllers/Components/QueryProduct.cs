using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuInShared.Brands;
using MuInShared.Feature;
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
			List<FeatureDto> features = new();
			HttpResponseMessage featureReponse = _httpClient.GetAsync(_httpClient.BaseAddress + "/Feature").Result;
			HttpResponseMessage brandReponse = _httpClient.GetAsync(_httpClient.BaseAddress + "/Brand").Result;
			if (featureReponse.IsSuccessStatusCode && brandReponse.IsSuccessStatusCode)
			{
				string featureData = featureReponse.Content.ReadAsStringAsync().Result;
				features = JsonConvert.DeserializeObject<List<FeatureDto>>(featureData);

				string brandData = brandReponse.Content.ReadAsStringAsync().Result;
				brands = JsonConvert.DeserializeObject<List<BrandDto>>(brandData);
			}
			ViewBag.BrandList = new SelectList(brands.Select(b => new { BrandAlias = b.Alias, Name = b.BrandName }), "BrandAlias", "Name");
			ViewBag.FeatureList = new SelectList(features.Select(f => new { FeatureAlias = f.Alias, Name = f.FeatureName }), "FeatureAlias", "Name");
			return View(query);
		}
	}
}
