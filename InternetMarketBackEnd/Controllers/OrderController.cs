using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Controllers.Common;
using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetMarketBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : BaseApiController, ICRUDController<Order>
    {
        private readonly IOrderAppService _orderAppService;


        public OrderController(IOrderAppService orderAppService)
        {
            if (orderAppService == null)
                throw new ArgumentNullException("IOrderAppService");
            _orderAppService = orderAppService;
        }

        public async Task<IActionResult> Add(Order order)
        {
            await _orderAppService.AddAsync(order);
            return Ok(order);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var order = _orderAppService.GetById(id);
            await _orderAppService.RemoveAsync(order);

            return Ok();
        }

        public async Task<IActionResult> GetOrderById(long id)
        {
            
            return Ok(_orderAppService.GetById(id));
        }

        public async Task<IActionResult> Update(Order id)
        {
            var order = _orderAppService.GetById(id);
            await _orderAppService.UpdateAsync(order);
            return Ok();
        }
    }
}