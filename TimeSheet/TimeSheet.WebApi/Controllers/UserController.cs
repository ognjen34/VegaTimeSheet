﻿using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeSheet.WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            User response = _mapper.Map<User>(user);
            await _userService.Add(response);
            return Ok(_mapper.Map<UserResponse>(response));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest oldUser)
        {
            User user = _mapper.Map<User>(oldUser);
            await _userService.Update(user);
            return Ok("LoggedUser Updated!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest credentials)
        {
            User user = await _userService.Login(credentials.Email, credentials.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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

            Response.Cookies.Append("jwtToken", tokenString, new CookieOptions
            {
                HttpOnly = false,     
                Secure = false,
                Expires = DateTime.UtcNow.AddDays(30),

            });

            return Ok(_mapper.Map<UserResponse>(user));
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Append("jwtToken", "", new CookieOptions
            {
                HttpOnly = true,
                Secure = false, 
                Expires = DateTime.UtcNow.AddYears(-1), 
            });

            return Ok(); 
        }

        [HttpGet()]
        public async Task<ActionResult> GetAll([FromQuery] PaginationRequest page)
        {

            PaginationReturnObject<User> users = await _userService.Search(_mapper.Map<Pagination>(page));

            return Ok(_mapper.Map<PaginationResponse<UserResponse>>(users));
        }
        [HttpGet("authenticate")]
        public async Task<ActionResult> Authenticate()
        {
            if (LoggedUser == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(LoggedUser);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            User user = await _userService.GetById(id);
            UserResponse response = _mapper.Map<UserResponse>(user);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.Delete(id);
            return Ok("LoggedUser Deleted!");
        }
    }
}
