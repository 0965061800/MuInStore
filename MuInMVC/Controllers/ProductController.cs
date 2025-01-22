using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuInMVC.Interfaces;
using MuInShared.Cart;
using MuInShared.Category;
using MuInShared.Comment;
using MuInShared.Product;

namespace MuInMVC.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly ICommentService _commentService;
		private readonly IProductSkuService _productSkuService;
		public ProductController(IProductService productService, ICategoryService categoryService, ICommentService commentService, IProductSkuService productSkuService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_commentService = commentService;
			_productSkuService = productSkuService;
		}

		[Route("[controller]")]
		[Route("[controller]/{catId:int}")]
		public IActionResult Index([FromQuery] SortFilterPageOptionRequest query, int catId)
		{
			if (query.PageNum == 0)
			{
				query.PageNum = 1;
			}
			if (query.PageSize == 0)
			{
				query.PageSize = 3;
			}
			if (catId != 0) query.CatId = catId;
			var productListCombine = _productService.GetProducts(query);
			if (productListCombine == null) return View("Error");
			var categoryList = _categoryService.GetCategories(catId);
			if (categoryList == null) categoryList = new List<CategoryDto>();
			ViewData["Categories"] = categoryList;
			return View(productListCombine);
		}


		public IActionResult ProductDetail(int id)
		{
			var productFullDto = _productService.GetProductById(id);
			if (productFullDto == null) return View("Error");

			ViewBag.ProductName = productFullDto.ProductName;

			if (productFullDto.ProductSkuDtos != null)
			{
				var colors = new SelectList(productFullDto.ProductSkuDtos
					.Where(p => p.ColorDto != null)
					.Select(p => new { p.ColorDtoId, Name = p.ColorDto.ColorName }), "ColorDtoId", "Name");

				ViewData["Colors"] = colors;
			}

			AddToCartVM addToCart = new AddToCartVM
			{
				ProductId = productFullDto.ProductId,
			};

			ViewBag.AddToCart = addToCart;
			RequestCommentDto commentDto = new RequestCommentDto();
			ViewBag.RequestCommentDto = commentDto;

			return View(productFullDto);
		}

		[HttpPost]
		[Route("[controller]/[action]/{productId}")]

		public async Task<IActionResult> CreateComment(int productId, RequestCommentDto requestCommentDto)
		{
			if (!ModelState.IsValid)
			{
				var message = string.Join(" | ", ModelState.Values
			   .SelectMany(v => v.Errors)
			   .Select(e => e.ErrorMessage));
				TempData["Message"] = message;
				return RedirectToAction("ProductDetail", new { id = productId });
			}
			var token = HttpContext.Session.GetString("JWToken");

			if (string.IsNullOrEmpty(token))
			{
				TempData["Message"] = "You need to login to comment";
				return RedirectToAction("ProductDetail", new { id = productId });
			}
			string result = await _commentService.PostComment(token, productId, requestCommentDto);
			if (result == "Success")
			{
				return RedirectToAction("ProductDetail", new { id = productId });
			}
			else
			{
				TempData["Message"] = result;
				return RedirectToAction("ProductDetail", new { id = productId });
			}
		}
		[HttpPost]
		[Route("[controller]/[action]")]
		public async Task<IActionResult> ChangeColor(int productId, int colorId)
		{
			var productSkuDto = await _productSkuService.GetProductSkuDto(productId, colorId);
			return Json(productSkuDto);
		}
	}
}