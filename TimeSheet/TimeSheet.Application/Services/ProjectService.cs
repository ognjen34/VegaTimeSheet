using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;

namespace TimeSheet.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task Add(Project project)
        {
            _projectRepository.Add(project);
        }

        public async Task Delete(Project project)
        {
            _projectRepository.Delete(project.Id.ToString());
        }

        public Task<IEnumerable<Project>> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public Task<Project> GetById(Guid id)
        {
            return _projectRepository.GetById(id.ToString());
        }

        public async Task Update(Project project)
        {
            _projectRepository.Update(project);
        }
    }
}
