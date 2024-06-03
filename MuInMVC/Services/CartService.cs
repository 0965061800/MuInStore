using MuInMVC.Interfaces;
using MuInShared.Cart;
using Newtonsoft.Json;
using System.Text;

namespace MuInMVC.Services
{
	public class CartService : ICartService
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public CartService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public List<CartItemReponse>? GetCartData(string cartData)
		{
			List<CartItemReponse> cartItemReponses = new List<CartItemReponse>();
			using (var client = new HttpClient())
			{
				StringContent content = new StringContent(cartData, Encoding.UTF8, "application/json");
				HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Cart", content).Result;
				if (response.IsSuccessStatusCode)
				{
					string result = response.Content.ReadAsStringAsync().Result;
					cartItemReponses = JsonConvert.DeserializeObject<List<CartItemReponse>>(result);
					return cartItemReponses;
				}
				return null;
			}
		}
	}
}
