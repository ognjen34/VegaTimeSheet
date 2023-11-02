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
    [Route("project")]
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
            await _projectService.Add(response);
            return Ok(_mapper.Map<ProjectRes>(response));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectReq updatedProject)
        {
            Project project = _mapper.Map<Project>(updatedProject);
            await _projectService.Update(project);
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
            Project project = await _projectService.GetById(id);
            ProjectRes response = _mapper.Map<ProjectRes>(project);
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
