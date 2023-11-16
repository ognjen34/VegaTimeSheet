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

        public async Task Add(Guid userId,WorkHour workHour)
        {
            WorkHourEntity workHourEntity = _mapper.Map<WorkHourEntity>(workHour);
            workHourEntity.UserId = userId.ToString();
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
 

        public async Task<IEnumerable<WorkHour>> GetUserCurrentDate(Guid userId, DateTime date)
        {
            var userWorkHoursEntity = await _context.WorkHours
                .Where(wh => wh.UserId == userId.ToString() && wh.Date.Date == date.Date)
                .ToListAsync();

            IEnumerable<WorkHour> result = userWorkHoursEntity
                .Select(workHourEntity => _mapper.Map<WorkHour>(workHourEntity))
                .ToList();
            return result;
        }



        public async Task<IEnumerable<WorkHour>> GetUsersWorkHoursForDateRange(Guid userId, DateTime startDate,DateTime endDate)
        {
            

            List<WorkHourEntity> userWorkHoursEntity = await _workHours
                .Where(wh => wh.UserId == userId.ToString() && wh.Date >= startDate && wh.Date <= endDate && wh.User.Id == userId.ToString())
                .ToListAsync();

            IEnumerable<WorkHour> result = userWorkHoursEntity
                .Select(workHourEntity => _mapper.Map<WorkHour>(workHourEntity))
                .ToList();

            return result;
        }

        public async Task<IEnumerable<WorkHour>> GetUsersWorkHoursForReports(CreateReport report)
        {
            var query = _workHours.AsQueryable();

            if (report.StartDate != null)
            {
                query = query.Where(wh => wh.Date >= report.StartDate);
            }

            if (report.EndDate != null)
            {
                query = query.Where(wh => wh.Date <= report.EndDate);
            }

            if (!string.IsNullOrEmpty(report.UserId))
            {
                query = query.Where(wh => wh.User.Id == report.UserId.ToString());
            }

            if (!string.IsNullOrEmpty(report.ClientId))
            {
                query = query.Where(wh => wh.Project.Client.Id == report.ClientId.ToString());
            }

            if (!string.IsNullOrEmpty(report.ProjectId))
            {
                query = query.Where(wh => wh.Project.Id == report.ProjectId.ToString());
            }

            if (!string.IsNullOrEmpty(report.CategoryId))
            {
                query = query.Where(wh => wh.Category.Id == report.CategoryId.ToString());
            }

            List<WorkHourEntity> userWorkHoursEntity = await query.ToListAsync();

            IEnumerable<WorkHour> result = userWorkHoursEntity
                .Select(workHourEntity => _mapper.Map<WorkHour>(workHourEntity))
                .ToList();

            return result;

        }

        public async Task Update(Guid userId, WorkHour workHour)
        {
            WorkHourEntity workHourEntity = await _workHours.FirstOrDefaultAsync(w => w.Id == workHour.Id.ToString());
            if (workHourEntity == null)
            {
                throw new ResourceNotFoundException("Work hour not found");
            }

            workHourEntity.Project = _mapper.Map<ProjectEntity>(workHour.Project);
            workHourEntity.ProjectId = workHour.ProjectId.ToString();
            workHourEntity.User = _mapper.Map<UserEntity>(workHour.User);
            workHourEntity.UserId = userId.ToString();
            workHourEntity.Description = workHour.Description;
            workHourEntity.Date = workHour.Date;   
            workHourEntity.Category = _mapper.Map<CategoryEntity>(workHour.Category);
            workHourEntity.CategoryId = workHour.CategoryId.ToString();
            workHourEntity.Time = workHour.Time;
            workHourEntity.OverTime = workHour.OverTime;

            await _context.SaveChangesAsync();
        }

        
    }
}
