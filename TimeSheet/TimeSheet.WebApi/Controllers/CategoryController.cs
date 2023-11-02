using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.Application.DTOs.Requests;
using TimeSheet.Application.DTOs.Responses;
using TimeSheet.Domain.Exceptions;
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
            try
            {
                await _categoryService.Add(response);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return BadRequest(ex.Message);
            }

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
            try
            {
                Category category = await _categoryService.GetById(id);
                CategoryRes response = _mapper.Map<CategoryRes>(category);
                return Ok(response);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            try
            {
                await _categoryService.Delete(id);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return NotFound(ex.Message);
            }
            return Ok("Category Deleted!");
        }
    }
}
