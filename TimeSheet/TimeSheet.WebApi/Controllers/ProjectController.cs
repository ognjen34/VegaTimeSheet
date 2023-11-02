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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectReq project)
        {
            Project response = _mapper.Map<Project>(project);
            try
            {
                await _projectService.Add(response);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return BadRequest(ex.Message);
            }

            return Ok(_mapper.Map<ProjectRes>(response));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectReq updatedProject)
        {
            Project project = _mapper.Map<Project>(updatedProject);
            try
            {
                await _projectService.Update(project);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return BadRequest(ex.Message);
            }

            return Ok("Project Updated!");
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAllProjects()
        {
            IEnumerable<Project> projects = await _projectService.GetAll();

            IEnumerable<ProjectRes> response = projects.Select(_mapper.Map<ProjectRes>).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectById(Guid id)
        {
            try
            {
                Project project = await _projectService.GetById(id);
                ProjectRes response = _mapper.Map<ProjectRes>(project);
                return Ok(response);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            try
            {
                await _projectService.Delete(id);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return NotFound(ex.Message);
            }
            return Ok("Project Deleted!");
        }
    }
}
