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

        public Task Add(Project project)
        {
            return _projectRepository.Add(project);
        }

        public  Task Delete(Guid id)
        {
            return _projectRepository.Delete(id.ToString());
        }

        public Task<PaginationReturnObject<Project>> Search(PaginationFilter page)
        {
            return _projectRepository.Search(page);
        }

        public Task<Project> GetById(Guid id)
        {
            return _projectRepository.GetById(id.ToString());
        }

        public async Task Update(Project project)
        {
            await _projectRepository.Update(project);
        }

        public Task<IEnumerable<Project>> GetProjectsFromClient(Guid id)
        {
            return _projectRepository.GetProjectsFromClient(id);
        }
    }
}
