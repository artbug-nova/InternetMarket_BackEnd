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
    public class CategoryController : BaseApiController, ICRUDController<Category>
    {
        public Task<IActionResult> Add(Category order)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetOrderById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update(Category id)
        {
            throw new NotImplementedException();
        }
    }
}