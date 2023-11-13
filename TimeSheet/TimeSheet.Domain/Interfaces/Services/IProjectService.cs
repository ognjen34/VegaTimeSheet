using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Services
{
    public interface IProjectService
    {
        Task<Project> GetById(Guid id);
        Task<PaginationReturnObject<Project>> Search(PaginationFilter page);
        Task Add(Project project);
        Task Update(Project project);
        Task Delete(Guid id);
        Task <IEnumerable<Project>> GetProjectsFromClient(Guid id);
    }
}
