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
            _workHourRepository.Add(workHour);
        }

        public async Task Delete(WorkHour workHour)
        {
            _workHourRepository.Delete(workHour.Id.ToString());
        }

        public Task<IEnumerable<WorkHour>> GetAll()
        {
            return _workHourRepository.GetAll();
        }

        public Task<WorkHour> GetById(Guid id)
        {
            return _workHourRepository.GetById(id.ToString());
        }

        public async Task Update(WorkHour workHour)
        {
            _workHourRepository.Update(workHour);
        }
    }
}
