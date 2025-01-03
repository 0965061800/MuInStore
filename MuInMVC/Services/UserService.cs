using MuInMVC.Interfaces;
using MuInShared.User;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MuInMVC.Services
{
	public class UserService : IUserService
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public UserService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public UserInfoDto? GetUserInfo(string token, string id)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			Console.WriteLine($"Token: {token}");
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Account/" + id).Result;
			Console.WriteLine("Request URL: " + _httpClient.BaseAddress + "/Account/" + id);
			Console.WriteLine("Authorization: " + _httpClient.DefaultRequestHeaders.Authorization);
			UserInfoDto userInfo = new UserInfoDto();

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				userInfo = JsonConvert.DeserializeObject<UserInfoDto>(data);
				return userInfo;
			}
			return null;
		}
	}
}
