using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.Application.DTOs.Requests;
using TimeSheet.Application.DTOs.Responses;
using TimeSheet.Domain.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization; // If you need authorization attributes

namespace TimeSheet.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkHourController : ControllerBase
    {
        private readonly IWorkHourService _workHourService;
        private readonly IMapper _mapper;

        public WorkHourController(IWorkHourService workHourService, IMapper mapper)
        {
            _workHourService = workHourService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateWorkHour([FromBody] CreateWorkHourReq workHour)
        {
            WorkHour response = _mapper.Map<WorkHour>(workHour);
            try
            {
                await _workHourService.Add(response);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return BadRequest(ex.Message);
            }

            return Ok(_mapper.Map<WorkHourRes>(response));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateWorkHour([FromBody] UpdateWorkHourReq updatedWorkHour)
        {
            WorkHour workHour = _mapper.Map<WorkHour>(updatedWorkHour);
            try
            {
                await _workHourService.Update(workHour);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return BadRequest(ex.Message);
            }

            return Ok("Work Hour Updated!");
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAllWorkHours()
        {
            IEnumerable<WorkHour> workHours = await _workHourService.GetAll();

            IEnumerable<WorkHourRes> response = workHours.Select(_mapper.Map<WorkHourRes>).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWorkHourById(Guid id)
        {
            try
            {
                WorkHour workHour = await _workHourService.GetById(id);
                WorkHourRes response = _mapper.Map<WorkHourRes>(workHour);
                return Ok(response);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkHour(Guid id)
        {
            try
            {
                await _workHourService.Delete(id);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return NotFound(ex.Message);
            }
            return Ok("Work Hour Deleted!");
        }
    }
}
