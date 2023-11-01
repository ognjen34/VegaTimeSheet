using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.Application.DTOs.Requests;
using TimeSheet.Application.DTOs.Responses;

namespace TimeSheet.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;



        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]

        public async Task<IActionResult> AddUser([FromBody] CreateUserReq user)
        {
            User response = new User()
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Status = Status.Active,
                Role = user.Role
            };

            await _userService.Add(response);
            return Ok(new CreateUserRes(response));
           

        }
        [HttpGet()]
        public async Task<ActionResult> getByAll()
        {
            IEnumerable<User> users = await _userService.GetAll();

            return Ok(users);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getById(Guid id)
        {

            var request = await _userService.GetById(id);
            if (request != null)
                return Ok(new CreateUserRes(request));
            else return NotFound();


        }
    }
}
