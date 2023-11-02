using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;

namespace TimeSheet.Application.Services
{
    public class WorkHourService : IWorkHourService
    {
        private readonly IWorkHourRepository _workHourRepository;

        public WorkHourService(IWorkHourRepository workHourRepository)
        {
            _workHourRepository = workHourRepository;
        }

        public async Task Add(WorkHour workHour)
        {
            await _workHourRepository.Add(workHour);
        }

        public  Task Delete(Guid id)
        {
            return _workHourRepository.Delete(id.ToString());
        }

        public Task<IEnumerable<WorkHour>> GetAll()
        {
            return _workHourRepository.GetAll();
        }

        public Task<WorkHour> GetById(Guid id)
        {
            return _workHourRepository.GetById(id.ToString());
        }

        public Task<IEnumerable<WorkHour>> GetUsersWorkHoursForDateRange(Guid userId, DateOnly startDate,DateOnly endDate)
        {
            return _workHourRepository.GetUsersWorkHoursForDateRange(userId, startDate,endDate);
        }

        public Task<IEnumerable<WorkHour>> GetUsersWorkHoursForReports(string? userId, string? clientId, string? projectId, string? categoryId, DateOnly startDate, DateOnly endDate)
        {
            return _workHourRepository.GetUsersWorkHoursForReports(userId, clientId, projectId, categoryId, startDate, endDate);
        }

        public  Task Update(WorkHour workHour)
        {
            return _workHourRepository.Update(workHour);
        }
    }
}
