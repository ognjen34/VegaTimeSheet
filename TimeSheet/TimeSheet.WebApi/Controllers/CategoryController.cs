using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;

namespace TimeSheet.WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;



        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategory()
        {
            Category c = new Category();
            c.Name = "test";
            c.Id = Guid.NewGuid();
            await _categoryService.Add(c);

            return Ok();


        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getById(Guid id)
        {

            var request = await _categoryService.GetById(id);
            if (request != null)
                return Ok(request);
            else return NotFound();


        }
    }
}
