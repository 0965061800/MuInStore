﻿using Microsoft.AspNetCore.Mvc;
using MuInMVC.Extension;
using MuInMVC.Interfaces;
using MuInMVC.ModelViews;
using MuInShared.Cart;
using Newtonsoft.Json;

namespace MuInMVC.Controllers
{
	public class CartController : Controller
	{
		ICartService _cartService;
		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}
		public List<AddToCartVM> GioHang
		{
			get
			{
				var gh = HttpContext.Session.Get<List<AddToCartVM>>("GioHang");
				if (gh == default(List<AddToCartVM>))
				{
					gh = new List<AddToCartVM>();
				}
				return gh;
			}
		}

		[HttpPost]
		public IActionResult AddToCart(AddToCartVM addToCartVM)
		{
			if (ModelState.IsValid)
			{
				List<AddToCartVM> cart = GioHang;
				try
				{
					AddToCartVM item = cart.SingleOrDefault(c => c.ProductId == addToCartVM.ProductId && c.ColorId == addToCartVM.ColorId);
					if (item != null)
					{
						item.Quantity = item.Quantity + addToCartVM.Quantity;
						HttpContext.Session.Set<List<AddToCartVM>>("GioHang", cart);
					}
					else
					{
						item = new AddToCartVM
						{
							ColorId = addToCartVM.ColorId,
							Quantity = addToCartVM.Quantity,
							ProductId = addToCartVM.ProductId,
						};
						cart.Add(item);
					}
					HttpContext.Session.Set<List<AddToCartVM>>("GioHang", cart);
					ViewBag.Message = "Thêm vào giỏ hàng thành công";
					return RedirectToAction("Index", "Product");

				}
				catch (Exception ex)
				{
					ViewBag.Message = "Thêm vào giỏ hàng thất bại";
					return RedirectToAction("Index", "Product");
				}
			}
			else
			{
				ViewBag.Message = "Thêm vào giỏ hàng thất bại";
				return RedirectToAction("Index", "Product");
			}
		}

		public async Task<IActionResult> Index()
		{
			List<AddToCartVM> cart = GioHang;

			if (cart == null || cart.Count == 0)
			{
				ViewBag.Message = "No Cart";
				return View();
			}
			string cartData = JsonConvert.SerializeObject(cart);
			var cartReponse = _cartService.GetCartData(cartData);
			if (cartReponse == null)
			{
				return View("Error");
			}
			return View(cartReponse);
		}

		public ActionResult Remove(int id, int colorId)
		{
			try
			{
				List<AddToCartVM> gioHang = GioHang;
				AddToCartVM item = gioHang.SingleOrDefault(p => p.ProductId == id && p.ColorId == colorId);
				if (item != null)
				{
					gioHang.Remove(item);
				}
				//luu lai session
				HttpContext.Session.Set<List<AddToCartVM>>("GioHang", gioHang);
				return RedirectToAction("Index");
			}
			catch
			{
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult UpdateCart([FromBody] List<CartUpdateModel> updatedItems)
		{
			List<AddToCartVM> gioHang = GioHang;
			try
			{
				foreach (var item in updatedItems)
				{
					AddToCartVM cartLine = gioHang.SingleOrDefault(c => c.ProductId == item.ProductId && c.ColorId == item.ColorId);
					cartLine.Quantity = item.Amount;
				}
				HttpContext.Session.Set<List<AddToCartVM>>("GioHang", gioHang);
				return Json(new { success = true });
			}
			catch (Exception ex)
			{
				// Handle the error
				return Json(new { success = false, message = ex.Message });
			}
		}

	}
}
