using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Controllers
{
    public interface IStoreController
    {
        IActionResult GetOrderById(long id);
        IActionResult Delete(long id);
        IActionResult Post(Order order);
        IActionResult Put(Order id);
    }
}
