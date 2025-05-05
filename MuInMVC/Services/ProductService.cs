using MuInMVC.Helpers;
using MuInMVC.Interfaces;
using MuInShared.Product;
using Newtonsoft.Json;

namespace MuInMVC.Services
{
	public class ProductService : IProductService
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public ProductService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public ProductListCombine? GetProducts(SortFilterPageOptionRequest query)
		{

			var queryString = QueryStringHelper.ToQueryString(query);

			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Product" + queryString).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				var productList = JsonConvert.DeserializeObject<ProductListCombine>(data);
				return productList;
			}
			return null;
		}

		public ProductFullDto? GetProductById(int id)
		{
			ProductFullDto productFullDto = new ProductFullDto();
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Product/" + id).Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				productFullDto = JsonConvert.DeserializeObject<ProductFullDto>(data);
				return productFullDto;
			}
			return null;
		}
	}
}
