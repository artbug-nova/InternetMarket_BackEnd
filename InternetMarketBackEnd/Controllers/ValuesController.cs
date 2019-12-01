using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InternetMarketBackEnd.Domain.Services;
using InternetMarketBackEnd.Infra.Repository;
using InternetMarketBackEnd.Infra.Data;
using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.CrossCutting.Ioc.Module;

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
        public IActionResult GetRole()
        {
            
            return Ok(this.service.Get());
        }
    }
}