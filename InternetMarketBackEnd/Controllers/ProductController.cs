using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _appService;
        public ProductController(IProductAppService appService)
        {
            _appService = appService;
        }
        public IActionResult Add()
        {
            _appService.Add(new Product
            {
                Name = "пылесос",
                Description = "Super pile",
                Price = 11
            });
            return Ok();
        }
    }
}
