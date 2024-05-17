using MuInShared.Order;
using MuInStoreAPI.Models;

namespace MuInStoreAPI.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                OrderId = order.OrderId,
                SumTotal = order.SumTotal,
                CreateDate = order.CreateDate,
                Address = order.Address,
                UserName = order.AppUser.UserName,
                Phone = order.AppUser.Phone,
            };
        }
    }
}
