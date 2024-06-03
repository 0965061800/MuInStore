using MuInMVC.Interfaces;
using MuInShared.Category;
using Newtonsoft.Json;

namespace MuInMVC.Services
{
	public class CategoryService : ICategoryService
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
		public CategoryService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = baseAddress;
		}

		public List<CategoryDto>? GetCategories()
		{
			List<CategoryDto> categoryList = new();
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Category").Result;

			if (response.IsSuccessStatusCode)
			{
				string catData = response.Content.ReadAsStringAsync().Result;
				categoryList = JsonConvert.DeserializeObject<List<CategoryDto>>(catData);
				return categoryList;
			}
			return null;
		}

		public CategoryFullDto? GetCategoryFull(int id)
		{
			CategoryFullDto categoryFullDto = new CategoryFullDto();
			HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Category/" + id).Result;
			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				categoryFullDto = JsonConvert.DeserializeObject<CategoryFullDto>(data);
				return categoryFullDto;
			}
			return null;
		}
	}
}
