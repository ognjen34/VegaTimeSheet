using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Repositories
{
    public interface IWorkHourRepository
    {
        Task<WorkHour> GetById(string id);
        Task<IEnumerable<WorkHour>> GetAll();
        Task Add(WorkHour workHour);
        Task Update(WorkHour workHour);
        Task Delete(string id);
    }
}
