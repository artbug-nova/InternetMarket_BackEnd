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
    [Route("[controller]")]
    public class StoreController : BaseApiController, IStoreController
    {
        private readonly IOrderAppService _orderAppService;


        public StoreController(IOrderAppService orderAppService)
        {
            if (orderAppService == null)
                throw new ArgumentNullException("IOrderAppService");
            _orderAppService = orderAppService;
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetOrderById(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Put(Order id)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}