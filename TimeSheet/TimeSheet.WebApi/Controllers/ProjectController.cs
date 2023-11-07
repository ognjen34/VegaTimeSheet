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
    [Route("projects")]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService, IMapper mapper) : base(mapper)
        {
            _projectService = projectService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest project)
        {
            Project response = _mapper.Map<Project>(project);
            await _projectService.Add(response);
            return Ok(_mapper.Map<ProjectResponse>(response));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectRequest updatedProject)
        {
            Project project = _mapper.Map<Project>(updatedProject);
            await _projectService.Update(project);
            return Ok("Project Updated!");
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllProjects([FromQuery] PaginationFilterRequest filter)
        {
            PaginationReturnObject<Project> response = await _projectService.Search(_mapper.Map<PaginationFilter>(filter));

            return Ok(_mapper.Map<PaginationResponse<ProjectResponse>>(response));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectById(Guid id)
        {
            Project project = await _projectService.GetById(id);
            ProjectResponse response = _mapper.Map<ProjectResponse>(project);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            await _projectService.Delete(id);
            return Ok("Project Deleted!");
        }
    }
}
