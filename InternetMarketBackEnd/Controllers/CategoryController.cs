using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Controllers.Common;
using InternetMarketBackEnd.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetMarketBackEnd.Controllers
{
    public class CategoryController : BaseApiController, ICRUDController<Category>
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException("ICategoryAppService");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            return Ok(await _categoryAppService.AddAsync(category));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var entity = await _categoryAppService.GetById(id);
            return Ok(_categoryAppService.RemoveAsync(entity));
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderById(long id)
        {
            return Ok(await _categoryAppService.GetById(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Category entity)
        {
            return Ok(await _categoryAppService.UpdateAsync(entity));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryAppService.GetAll());
        }
    }
}