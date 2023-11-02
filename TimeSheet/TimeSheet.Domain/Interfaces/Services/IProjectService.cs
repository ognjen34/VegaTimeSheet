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
        Task<IEnumerable<Project>> GetAll();
        Task Add(Project project);
        Task Update(Project project);
        Task Delete(Guid id);
    }
}
