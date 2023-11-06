using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TimeSheet.Application.Services;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;

namespace TimeSheet.WebApi.Controllers
{
    [ApiController]
    [Route("monthlyhours")]
    public class MonthlyHoursController :ControllerBase
    {
        private readonly IMonthlyHoursService _monthlyHoursService;
        private readonly IMapper _mapper;

        public MonthlyHoursController(IMonthlyHoursService monthlyHoursService, IMapper mapper)
        {
            _monthlyHoursService = monthlyHoursService;
            _mapper = mapper;
        }
        [Authorize(Policy ="AuthorizedOnly")]
        [HttpPost("")]
        public async Task<ActionResult> GetUserMonthlyHours([FromBody] DateRangeDTO dates)
        {
            Guid id = (Guid)HttpContext.Items["UserId"];
            MonthlyHours response = await _monthlyHoursService.GetUsersMontlyHours(id,dates.StartDate, dates.EndDate);
            return Ok(response);
        }
    }
}
