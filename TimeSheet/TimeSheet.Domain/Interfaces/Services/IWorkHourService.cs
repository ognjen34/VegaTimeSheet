using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Services
{
    public interface IWorkHourService
    {
        Task<WorkHour> GetById(Guid id);
        Task<IEnumerable<WorkHour>> GetAll();
        Task Add(Guid userId,WorkHour workHour);
        Task Update(Guid userId, WorkHour workHour);
        Task Delete(Guid id);
        Task<IEnumerable<WorkHour>> GetUsersWorkHoursForDateRange(Guid userId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<WorkHour>> GetUsersWorkHoursForReports(CreateReport report);
        Task <IEnumerable<WorkHour>> GetUserCurrentDate(Guid userId, DateTime date);
    }
}
