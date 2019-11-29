using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace InternetMarketBackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Route("getrole")]
        [HttpGet]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: администратор");
        }
    }
}