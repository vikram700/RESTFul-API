using System.Runtime.Intrinsics.X86;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{   
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService,
                                        IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // Get Method
        [HttpGet]
        public async Task<IEnumerable<CategoryResource > > GetAll()
        {
            var categories = await _categoryService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Category >, IEnumerable<CategoryResource> >(categories);

            return resources;
        }

        //Post Method
        [HttpPost]
        public async Task<IActionResult > PostAsync([FromBody] SaveCategoryResource resource)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCategoryResource, Category>(resource); 

            var result = await _categoryService.PostAsync(category);

            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);

        }


        // Update Method
        [HttpPut("{id}")]
        public async Task<IActionResult > PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);

            var result = await _categoryService.PutAsync(id, category);

            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }

        // Delete Method
        [HttpDelete("{id}")]
        public async Task<IActionResult > DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if(!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);

            return Ok(categoryResource);
        }
    }
}