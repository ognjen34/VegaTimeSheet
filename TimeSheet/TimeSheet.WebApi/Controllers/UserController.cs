using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.Application.DTOs.Requests;
using TimeSheet.Application.DTOs.Responses;
using TimeSheet.Domain.Exceptions;
using AutoMapper;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TimeSheet.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;



        public UserController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserReq user)
        {
            User response = _mapper.Map<User>(user);
            try
            {
                await _userService.Add(response);
            }
            catch (EmailAlreadyExistException ex) 
            {
                return BadRequest(ex.Message);
            }

            return Ok(_mapper.Map<UserRes>(response));
           

        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserReq oldUser)
        {
            User user = _mapper.Map<User>(oldUser);
            try
            {
                await _userService.Update(user);
            }
            catch (EmailAlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("User Updated!");


        }
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginReq credentials)
        {

            try
            {
                User user = await _userService.Login(credentials.Email, credentials.Password);

                if (user == null)
                {
                    return Unauthorized(); 
                }

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                     };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("testvegatestvegatestvega"));
                var credentialsJWT = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: null,
                    audience: null, 
                    claims,
                    expires: DateTime.Now.AddMinutes(60), 
                    signingCredentials: credentialsJWT
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = tokenString, User = _mapper.Map<UserRes>(user) });

            }
            catch (ResourceNotFoundException ex) 
            {
                return NotFound(ex.Message);
            }



        }


        //[Authorize(Policy = "AdminOnly")]
        [HttpGet()]
        public async Task<ActionResult> GetByAll()
        {
            IEnumerable<User> users = await _userService.GetAll();

            IEnumerable<UserRes> response = users.Select(_mapper.Map<UserRes>).ToList();

            return Ok(response);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                User user = await _userService.GetById(id);
                UserRes response = _mapper.Map<UserRes>(user);
                return Ok(response);
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }


        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.Delete(id);
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok("User Deleted!");


        }
    }
}
