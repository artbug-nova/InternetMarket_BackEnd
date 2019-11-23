using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetMarketBackEnd.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetMarketBackEnd.Controllers
{
    [Route("[controller]")]
    public class StoreController : BaseApiController
    {
        [Route("Res")]
        public string Result()
        {
            return "Hello APp";
        }
    }
}