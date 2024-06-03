using MuInMVC.Interfaces;
using MuInShared.Comment;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MuInMVC.Services
{
	public class CommentService : ICommentService
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public CommentService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public async Task<string> PostComment(string token, int productId, RequestCommentDto requestCommentDto)
		{
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			string data = JsonConvert.SerializeObject(requestCommentDto);
			StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
			HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Comment/" + productId, content).Result;
			if (response.IsSuccessStatusCode)
			{
				return "Success";
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}
