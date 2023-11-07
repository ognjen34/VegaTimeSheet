using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace TimeSheet.WebApi.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IMapper mapper):base(mapper)
        {
            _categoryService = categoryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest category)
        {
            Category response = _mapper.Map<Category>(category);
            await _categoryService.Add(response);
            return Ok(_mapper.Map<CategoryResponse>(response));
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllCategories([FromQuery] PaginationFilterRequest filter)
        {
            PaginationReturnObject<Category> categories = await _categoryService.Search(_mapper.Map<PaginationFilter>(filter)); ;
            

            return Ok(_mapper.Map<PaginationResponse<CategoryResponse>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(Guid id)
        {
            Category category = await _categoryService.GetById(id);
            CategoryResponse response = _mapper.Map<CategoryResponse>(category);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            await _categoryService.Delete(id);
            return Ok("Category Deleted!");
        }
    }
}
