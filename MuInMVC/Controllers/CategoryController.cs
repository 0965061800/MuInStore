using Microsoft.AspNetCore.Mvc;
using MuInMVC.Interfaces;

namespace MuInMVC.Controllers
{
	public class CategoryController : Controller
	{
		ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult Index(int id)
		{
			var categoryFullDto = _categoryService.GetCategoryFull(id);
			if (categoryFullDto == null)
			{
				return View("Error");
			}
			ViewBag.CatName = categoryFullDto.CatName;
			ViewData["Categories"] = categoryFullDto.SubCategories;
			return View(categoryFullDto.AllProducts);
		}
	}
}
