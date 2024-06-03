using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuInMVC.Interfaces;
using MuInShared.Cart;
using MuInShared.Comment;
using MuInShared.Helpers;
using System.Text;

namespace MuInMVC.Controllers
{
	public class ProductController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7137/api");
		private readonly HttpClient _httpClient;
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

		public IActionResult Index()
		{
			ProductQueryObject query = new ProductQueryObject();
			var productList = _productService.GetProducts(query);
			if (productList == null) return View("Error");
			var categoryList = _categoryService.GetCategories();
			ViewData["Categories"] = categoryList;
			return View(productList.Data);
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

		public async Task<IActionResult> CreateCommentAsync(int productId, RequestCommentDto requestCommentDto)
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
		public IActionResult Filter(ProductQueryObject query)
		{
			var productList = _productService.GetProducts(query);
			if (productList == null) return View("Error");
			var categoryList = _categoryService.GetCategories();
			ViewData["Categories"] = categoryList;
			return View("Index", productList.Data);
		}

		public async Task<IActionResult> ChangeColor(int productId, int colorId)
		{
			var productSkuDto = _productSkuService.GetProductSkuDto(productId, colorId);
			return Json(productSkuDto);
		}
	}
}