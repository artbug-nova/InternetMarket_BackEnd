using System;
using Microsoft.AspNetCore.Mvc;

namespace InternetMarketBackEnd.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase, IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
        }

        ~BaseApiController()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
}