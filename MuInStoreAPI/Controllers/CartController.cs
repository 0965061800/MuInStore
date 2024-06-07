using Microsoft.AspNetCore.Mvc;
using MuInShared.Cart;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;
using System.Linq.Expressions;

namespace MuInStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public CartController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpPost]
        public async Task<IActionResult> GetCartDetail([FromBody] List<AddToCartVM> cartItems)
        {
            List<CartItemReponse> cartItemReponse = new List<CartItemReponse>();
            foreach (var item in cartItems)
            {
                Expression<Func<ProductSku, bool>> filter = p => p.ProductId == item.ProductId && p.ColorId == item.ColorId;

                var productSkus = await _uow.ProductSkuRepository.GetAll(filter: filter, includeProperties: "Color,Product");
                ProductSku productSku = productSkus.FirstOrDefault();

                CartItemReponse newCartItemReponse = new CartItemReponse
                {
                    ProductId = item.ProductId,
                    ProductName = productSku.Product.ProductName,
                    ProductImage = productSku.Images == null ? productSku.Images.FirstOrDefault().ImageUrl : "",
                    ProductSkuId = productSku.ProductSkuId,
                    UnitPrice = productSku.UnitPrice,
                    Amount = item.Quantity,
                    ColorId = item.ColorId,
                    ColorName = productSku.Color.ColorName
                };

                cartItemReponse.Add(newCartItemReponse);
            }
            return Ok(cartItemReponse);
        }

    }
}
