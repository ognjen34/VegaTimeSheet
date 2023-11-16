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

        public async Task Add(Guid userId,WorkHour workHour)
        {
            await _workHourRepository.Add(userId,workHour);
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

        public Task<IEnumerable<WorkHour>> GetUserCurrentDate(Guid userId, DateTime date)
        {
            return _workHourRepository.GetUserCurrentDate(userId, date);
        }

        public Task<IEnumerable<WorkHour>> GetUsersWorkHoursForDateRange(Guid userId, DateTime startDate,DateTime endDate)
        {
            return _workHourRepository.GetUsersWorkHoursForDateRange(userId, startDate,endDate);
        }

        public Task<IEnumerable<WorkHour>> GetUsersWorkHoursForReports(CreateReport report)
        {
            return _workHourRepository.GetUsersWorkHoursForReports(report);
        }

        public  Task Update(Guid userId, WorkHour workHour)
        {
            return _workHourRepository.Update(userId,workHour);
        }
    }
}
