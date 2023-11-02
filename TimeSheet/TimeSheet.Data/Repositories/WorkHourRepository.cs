using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Data.Data;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Repositories
{
    public class WorkHourRepository : 
        IWorkHourRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<WorkHourEntity> _workHours;
        private readonly DatabaseContext _context;

        public WorkHourRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _workHours = context.Set<WorkHourEntity>();
            _mapper = mapper;
        }

        public async Task Add(WorkHour workHour)
        {
            WorkHourEntity workHourEntity = _mapper.Map<WorkHourEntity>(workHour);
            await _workHours.AddAsync(workHourEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            WorkHourEntity workHourDb = await _workHours.FirstOrDefaultAsync(w => w.Id == id);
            if (workHourDb == null)
            {
                throw new ResourceNotFoundException("Work hour not found");
            }

            _workHours.Remove(workHourDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkHour>> GetAll()
        {
            List<WorkHourEntity> workHourEntities = await _workHours.ToListAsync();
            List<WorkHour> result = workHourEntities.Select(workHourEntity => _mapper.Map<WorkHour>(workHourEntity)).ToList();

            return result;
        }

        public async Task<WorkHour> GetById(string id)
        {
            WorkHourEntity workHourEntity = await _workHours.FirstOrDefaultAsync(w => w.Id == id);

            if (workHourEntity != null)
            {
                return _mapper.Map<WorkHour>(workHourEntity);
            }
            else
            {
                throw new ResourceNotFoundException("Work hour not found");
            }
        }

        public async Task<IEnumerable<WorkHour>> GetUsersWorkHoursForDateRange(Guid userId, DateOnly startDate,DateOnly endDate)
        {
            

            List<WorkHourEntity> userWorkHoursEntity = await _workHours
                .Where(wh => wh.UserId == userId.ToString() && wh.Date >= startDate && wh.Date <= endDate && wh.User.Id == userId.ToString())
                .ToListAsync();

            IEnumerable<WorkHour> result = userWorkHoursEntity
                .Select(workHourEntity => _mapper.Map<WorkHour>(workHourEntity))
                .ToList();

            return result;
        }

        public async Task<IEnumerable<WorkHour>> GetUsersWorkHoursForReports(string? userId, string? clientId, string? projectId, string? categoryId, DateOnly startDate, DateOnly endDate)
        {
            var query = _workHours.Where(wh => wh.Date >= startDate && wh.Date <= endDate);

            if (userId != null)
            {
                query = query.Where(wh => wh.User.Id == userId.ToString());
            }

            if (clientId != null)
            {
                query = query.Where(wh => wh.Project.Client.Id == clientId.ToString());
            }

            if (projectId != null)
            {
                query = query.Where(wh => wh.Project.Id == projectId.ToString());
            }

            if (categoryId != null)
            {
                query = query.Where(wh => wh.Category.Id == categoryId.ToString());
            }

            List<WorkHourEntity> userWorkHoursEntity = await query.ToListAsync();

            IEnumerable<WorkHour> result = userWorkHoursEntity
                .Select(workHourEntity => _mapper.Map<WorkHour>(workHourEntity))
                .ToList();

            return result;
        }

        public async Task Update(WorkHour workHour)
        {
            WorkHourEntity workHourEntity = await _workHours.FirstOrDefaultAsync(w => w.Id == workHour.Id.ToString());
            if (workHourEntity == null)
            {
                throw new ResourceNotFoundException("Work hour not found");
            }

            workHourEntity.Project = _mapper.Map<ProjectEntity>(workHour.Project);
            workHourEntity.User = _mapper.Map<UserEntity>(workHour.User);
            workHourEntity.Description = workHour.Description;
            workHourEntity.Date = workHour.Date;   
            workHourEntity.Category = _mapper.Map<CategoryEntity>(workHour.Category);

            await _context.SaveChangesAsync();
        }
    }
}
