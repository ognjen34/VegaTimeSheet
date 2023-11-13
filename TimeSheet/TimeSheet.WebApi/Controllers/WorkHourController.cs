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
    [Route("workhours")]
    public class WorkHourController : BaseController
    {
        private readonly IWorkHourService _workHourService;

        public WorkHourController(IWorkHourService workHourService, IMapper mapper):base(mapper) 
        {
            _workHourService = workHourService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateWorkHour([FromBody] CreateWorkHourRequest workHour)
        {
            WorkHour response = _mapper.Map<WorkHour>(workHour);

            await _workHourService.Add(response);
            return Ok(_mapper.Map<WorkHourResponse>(response));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateWorkHour([FromBody] UpdateWorkHourRequest updatedWorkHour)
        {
            WorkHour workHour = _mapper.Map<WorkHour>(updatedWorkHour);
            await _workHourService.Update(workHour);
            return Ok("Work Hour Updated!");
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllWorkHours()
        {
            IEnumerable<WorkHour> workHours = await _workHourService.GetAll();
            IEnumerable<WorkHourResponse> response = workHours.Select(_mapper.Map<WorkHourResponse>).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWorkHourById(Guid id)
        {
            WorkHour workHour = await _workHourService.GetById(id);
            WorkHourResponse response = _mapper.Map<WorkHourResponse>(workHour);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkHour(Guid id)
        {
            await _workHourService.Delete(id);
            return Ok("Work Hour Deleted!");
        }
        [HttpGet("workday/{date}")]
        public async Task<ActionResult> GetUserCurrentDay(DateTime date)
        {
            IEnumerable<WorkHour> response = await _workHourService.GetUserCurrentDate(LoggedUser.UserId, date);
            return Ok(_mapper.Map<IEnumerable<WorkDayResponse>>(response));
        }
    }
}
