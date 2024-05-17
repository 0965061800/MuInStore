using Microsoft.AspNetCore.Mvc;
using MuInShared.Category;
using MuInShared.Helpers;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;

namespace MuInStoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly IUnitOfWork _uow;
		public CategoryController(IUnitOfWork uow)
		{
			_uow = uow;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory([FromHeader] CatQueryObject catQuery)
		{
			var categories = await _uow.CategoryRepository.GetAll(filter: x => x.ParentCatId == catQuery.ParentId);
			if (categories == null)
			{
				return NotFound("There is no category in your database");
			}
			var categorieDtos = categories.Select(x => x.ToCategoryDto());
			return Ok(categorieDtos);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Category>> GetCategoryById(int id)
		{
			var category = await _uow.CategoryRepository.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound("No category found");
			}
			var allProducts = new List<Product>();
			CollectProducts(category, allProducts);

			CategoryFullDto categoryDto = category.ToCategoryFullDto(allProducts);
			return Ok(categoryDto);
		}

		private void CollectProducts(Category category, List<Product> products)
		{
			products.AddRange(category.Products);
			foreach (var childCategory in category.Subcategories)
			{
				CollectProducts(childCategory, products);
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(RequestCatDto requestCatDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			Category category = requestCatDto.ToCategoryFromRequest();
			try
			{
				await _uow.CategoryRepository.Create(category);
				await _uow.Save();
				return Ok(category.ToCategoryDto());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCategory(int id, RequestCatDto requestCatDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var category = await _uow.CategoryRepository.GetById(id);
			if (category == null)
			{
				return NotFound("No Category Found");
			}
			category = requestCatDto.ToUpdateCategory(category);
			try
			{
				await _uow.CategoryRepository.Update(id, category);
				await _uow.Save();
				return Ok(category.ToCategoryDto());
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var category = await _uow.CategoryRepository.GetById(id);
			if (category == null)
			{
				return NotFound("No Category Found");
			}
			try
			{
				await _uow.CategoryRepository.Delete(id);
				await _uow.Save();
				return Ok($"Delete Category {category.CatName} successfully");
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}

