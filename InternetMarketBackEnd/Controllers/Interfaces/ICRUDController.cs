using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMarketBackEnd.Controllers
{
    public interface ICRUDController<TEntity>
    {
        Task<IActionResult> GetOrderById(long id);
        Task<IActionResult> Add(TEntity entity);
        Task<IActionResult> Update(TEntity entity);
        Task<IActionResult> Delete(long id);
    }
}
