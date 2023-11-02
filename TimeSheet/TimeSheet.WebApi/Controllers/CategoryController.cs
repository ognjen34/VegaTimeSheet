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
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryReq category)
        {
            Category response = _mapper.Map<Category>(category);
            await _categoryService.Add(response);
            return Ok(_mapper.Map<CategoryRes>(response));
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAllCategories()
        {
            IEnumerable<Category> categories = await _categoryService.GetAll();
            IEnumerable<CategoryRes> response = categories.Select(_mapper.Map<CategoryRes>).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(Guid id)
        {
            Category category = await _categoryService.GetById(id);
            CategoryRes response = _mapper.Map<CategoryRes>(category);
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
