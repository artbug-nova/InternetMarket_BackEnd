using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetMarketBackEnd.Controllers.Common;
using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetMarketBackEnd.Controllers
{
    [Route("[controller]")]
    public class StoreController : BaseApiController, IStoreController
    {
        //private IOrderAppService
        public IActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetOrderById(long id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Post(Order order)
        {
            throw new NotImplementedException();
        }

        public IActionResult Put(Order id)
        {
            throw new NotImplementedException();
        }
    }
}