using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuInShared.Cart;
using MuInShared.Checkout;
using MuInStoreAPI.Extensions;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;

namespace MuInStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly UserManager<AppUser> _userManager;
        public CheckoutController(IUnitOfWork uow, UserManager<AppUser> userManager)
        {
            _uow = uow;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout([FromBody] RequestCheckout requestCheckout)
        {
            List<CartItemReponse> cart = requestCheckout.cart;
            CheckoutVM userInfo = requestCheckout.userInfo;
            try
            {
                var username = User.GetUserName();
                var appUser = await _userManager.FindByNameAsync(username);
                await _uow.BeginTransactionAsync();
                try
                {
                    AppUser user = _userManager.Users.First(x => x.UserName == username);
                    if (user.Address == null && userInfo?.Address != null) user.Address = userInfo.Address;
                    if (user.Phone == null && userInfo?.Phone != null) user.Phone = userInfo.Phone;
                    if (user.FirstName == "" && userInfo?.FullName != null) user.FirstName = userInfo.FullName;
                    await _userManager.UpdateAsync(user);

                    Payment newPayment = new Payment
                    {
                        Amount = Convert.ToInt32(cart.Sum(x => x.TotalMoney)),
                        PayStatusId = 1
                    };
                    await _uow.PaymentRepository.Create(newPayment);
                    await _uow.Save();

                    Order newOrder = new Order
                    {
                        SumTotal = Convert.ToInt32(cart.Sum(x => x.TotalMoney)),
                        Address = userInfo.Address,
                        PaymentId = newPayment.PaymentId,
                        AppUserId = appUser.Id,
                    };
                    await _uow.OrderRepository.Create(newOrder);
                    await _uow.Save();

                    foreach (var item in cart)
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = newOrder.OrderId,
                            ProductSkuId = item.ProductSkuId,
                            Quantity = item.Amount,
                            Total = (decimal)item.TotalMoney,
                            ColorName = item.ColorName ?? "",
                            ProductName = item.ProductName ?? "",
                            ProductId = item.ProductId,
                            UnitPrice = item.UnitPrice,
                        };
                        await _uow.OrderDetailRepository.Create(orderDetail);
                    }
                    await _uow.Save();
                    await _uow.CommitAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    await _uow.RollbackAsync();
                    return StatusCode(500, ex.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
