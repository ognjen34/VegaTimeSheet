using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using TimeSheet.Application.Services;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;

namespace TimeSheet.WebApi.Controllers
{
    [ApiController]
    [Route("monthlyhours")]
    public class MonthlyHoursController :BaseController
    {
        private readonly IMonthlyHoursService _monthlyHoursService;

        public MonthlyHoursController(IMonthlyHoursService monthlyHoursService, IMapper mapper):base(mapper) 
        {
            _monthlyHoursService = monthlyHoursService;
        }
        [Authorize(Policy ="AuthorizedOnly")]
        [HttpPost("")]
        public async Task<ActionResult> GetUserMonthlyHours([FromBody] DateRangeDTO dates)
        {
            
            MonthlyHours response = await _monthlyHoursService.GetUsersMontlyHours(LoggedUser.UserId, dates.StartDate, dates.EndDate);
            return Ok(response);
        }

    }
}
