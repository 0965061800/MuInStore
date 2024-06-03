using MuInMVC.Interfaces;
using MuInShared.Order;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MuInMVC.Services
{
	public class OrderService : IOrderService
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public OrderService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public List<OrderFullDto>? GetOrderByUser(string token)
		{
			List<OrderFullDto> orders = new List<OrderFullDto>();
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Order/User").Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				orders = JsonConvert.DeserializeObject<List<OrderFullDto>>(data);
				return orders;
			}
			return null;
		}
	}
}
