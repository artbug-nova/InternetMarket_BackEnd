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
        Task<IActionResult> Add(TEntity order);
        Task<IActionResult> Update(TEntity id);
        Task<IActionResult> Delete(long id);
    }
}
