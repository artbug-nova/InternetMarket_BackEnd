using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Controllers.Common;
using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetMarketBackEnd.Controllers
{
    
    public class OrderController : BaseApiController, ICRUDController<Order>
    {
        private readonly IOrderAppService _orderAppService;


        public OrderController(IOrderAppService orderAppService)
        {
            if (orderAppService == null)
                throw new ArgumentNullException("IOrderAppService");
            _orderAppService = orderAppService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            await _orderAppService.AddAsync(order);
            return Ok(order);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var order = _orderAppService.GetById(id);
            await _orderAppService.RemoveAsync(order);

            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrderById(long id)
        {
            
            return Ok(_orderAppService.GetById(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            
            var orders = _orderAppService.GetById(order.Id);
            await _orderAppService.UpdateAsync(orders);
            return Ok();
        }
    }
}