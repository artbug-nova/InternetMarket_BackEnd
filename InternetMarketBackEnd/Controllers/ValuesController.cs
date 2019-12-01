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
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IOrderAppService service;
        public ValuesController(IOrderAppService service)
        {
            this.service = service;
        }
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Route("getrole")]
        [HttpGet]
        public IActionResult GetRole(int price)
        {
            service.Add(new Order{ 

                Price = price
            });
            
            return Ok(this.service.Get());
        }
    }
}