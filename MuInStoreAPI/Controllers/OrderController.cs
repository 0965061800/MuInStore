﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuInShared.Order;
using MuInStoreAPI.Extensions;
using MuInStoreAPI.Mappers;
using MuInStoreAPI.Models;
using MuInStoreAPI.UnitOfWork;

namespace MuInStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly UserManager<AppUser> _userManager;
        public OrderController(IUnitOfWork uow, UserManager<AppUser> userManager)
        {
            _uow = uow;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrder()
        {
            var orders = await _uow.OrderRepository.GetAllOrderAsync();
            if (orders == null)
            {
                return NotFound("No Orders in your database");
            }
            var orderDtos = orders.OrderByDescending(x => x.CreateDate).Select(o => o.ToOrderDto()).ToList();
            return Ok(orderDtos);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderFullDto>> GetOrderById(int id)
        {
            var order = await _uow.OrderRepository.GetOrderById(id);
            if (order == null)
            {
                return NotFound("No order found");
            }
            OrderFullDto orderDto = order.ToOrderFullDto();
            return Ok(orderDto);
        }

        [HttpGet]
        [Route("/api/Order/User")]
        [Authorize]
        public async Task<ActionResult> GetOrderByName()
        {
            var username = User.GetUserName();
            var orders = await _uow.OrderRepository.GetOrderByUserName(username);
            if (orders != null)
            {
                var orderDto = orders.Select(o => o.ToOrderFullDto()).ToList();
                return Ok(orderDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
