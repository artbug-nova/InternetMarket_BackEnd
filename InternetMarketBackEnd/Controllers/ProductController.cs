using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Controllers.Common;
using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseApiController, ICRUDController<Product>
    {
        private readonly IProductAppService _appService;
        public ProductController(IProductAppService appService)
        {
            _appService = appService;
        }

        public async Task<IActionResult> Add(Product order)
        {
            await _appService.AddAsync(order);
            return Ok();
        }

        public async Task<IActionResult> Delete(long id)
        {
            var Product = _appService.GetById(id);
            await _appService.RemoveAsync(Product);
            return Ok();
        }

        public async Task<IActionResult> GetOrderById(long id)
        {
            return Ok(_appService.GetById(id));
        }

        public async Task<IActionResult> Update(Product id)
        {
            var Product = _appService.GetById(id);
            await _appService.UpdateAsync(Product);
            return Ok();
        }
    }
}
