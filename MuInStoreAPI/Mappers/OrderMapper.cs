﻿using MuInShared.Order;
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
                TransactionStatus = order.Payment.PayStatus.Status
            };
        }

        public static OrderFullDto ToOrderFullDto(this Order order)
        {
            return new OrderFullDto
            {
                OrderId = order.OrderId,
                SumTotal = order.SumTotal,
                CreateDate = order.CreateDate,
                Address = order.Address,
                FirstName = order.AppUser.FirstName ?? "",
                Phone = order.AppUser.Phone,
                TransactionStatus = order.Payment.PayStatus.Status,
                orderDetailDtos = order.OrderDetails.Select(x => x.ToOrderDetailDto()).ToList()
            };
        }
    }
}
