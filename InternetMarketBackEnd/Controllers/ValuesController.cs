using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InternetMarketBackEnd.Domain.Services;
using InternetMarketBackEnd.Infra.Repository;
using InternetMarketBackEnd.Infra.Data;
using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.CrossCutting.Ioc.Module;
using InternetMarketBackEnd.Domain.Entity;

namespace InternetMarketBackEnd.Controllers
{
    //api/values/getrole
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IOrderAppService service;
        public ValuesController(IOrderAppService service)
        {
            this.service = service;
        }
        [Route("update")]
        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {
            Order a = service.GetById(order.Id);
            a.ProductId= order.ProductId;
            a.Price = order.Price;
            a.Name = order.Name;
            service.Update(order);
            return Ok(a);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddOrder([FromBody]Order order)
        {
            service.Add(new Order{ 
                Name = order.Name,
                ProductId = order.ProductId,
                Price = order.Price
            });
            
            return Ok(order);
        }
    }
}