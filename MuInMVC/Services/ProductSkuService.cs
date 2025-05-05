using MuInMVC.Helpers;
using MuInMVC.Interfaces;
using MuInShared.ProductSku;
using Newtonsoft.Json;

namespace MuInMVC.Services
{
	public class ProductSkuService : IProductSkuService
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public ProductSkuService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public async Task<ProductSkuDto?> GetProductSkuDto(int productId, int colorId)
		{

			ProductSkuDto productSkuDto = new ProductSkuDto();
			var data = new
			{
				productId = productId,
				colorId = colorId,
			};

			var queryString = QueryStringHelper.ToQueryString(data);
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/ProductSku" + queryString).Result;

			if (response.IsSuccessStatusCode)
			{
				string result = response.Content.ReadAsStringAsync().Result;
				productSkuDto = JsonConvert.DeserializeObject<ProductSkuDto>(result);
				return productSkuDto;
			}
			return null;
		}
	}
}
