using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Data.Data;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Repositories
{
    public class WorkHourRepository : IWorkHourRepository
    {
        private readonly DbSet<WorkHourEntity> _workHours;
        private readonly DatabaseContex _context;

        public WorkHourRepository(DatabaseContex context)
        {
            _context = context;
            _workHours = context.Set<WorkHourEntity>();
        }

        public async Task Add(WorkHour workHour)
        {
            try
            {
                await _workHours.AddAsync(new WorkHourEntity 
                {
                    Id = workHour.Id.ToString(),
                    Project = workHour.Project,
                    Category = workHour.Category,
                    Description=workHour.Description,
                    Date = workHour.Date,
                    Time = workHour.Time,
                    OverTime = workHour.OverTime ,
                    User= workHour.User 
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add work hour.", ex);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                WorkHourEntity workHourDb = await _workHours.FirstOrDefaultAsync(w => w.Id == id);
                if (workHourDb == null)
                    throw new Exception("NotFound");

                _workHours.Remove(workHourDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete work hour.", ex);
            }
        }

        public async Task<IEnumerable<WorkHour>> GetAll()
        {
            try
            {
                List<WorkHourEntity> workHours = await _workHours.ToListAsync();

                List<WorkHour> result = new List<WorkHour>();
                foreach (WorkHourEntity workHourEntity in workHours)
                {
                    WorkHour workHour = new WorkHour
                    {
                        Id = Guid.Parse(workHourEntity.Id),
                        Project = workHourEntity.Project,
                        Category = workHourEntity.Category,
                        Description = workHourEntity.Description,
                        Date = workHourEntity.Date,
                        Time = workHourEntity.Time,
                        OverTime = workHourEntity.OverTime,
                        User = workHourEntity.User
                    };
                    result.Add(workHour);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve work hours.", ex);
            }
        }

        public async Task<WorkHour> GetById(string id)
        {
            try
            {
                WorkHourEntity workHourEntity = await _workHours.FirstOrDefaultAsync(w => w.Id == id.ToString());

                if (workHourEntity != null)
                {
                    return new WorkHour
                    {
                        Id = Guid.Parse(workHourEntity.Id),
                        Project = workHourEntity.Project,
                        Category = workHourEntity.Category,
                        Description = workHourEntity.Description,
                        Date = workHourEntity.Date,
                        Time = workHourEntity.Time,
                        OverTime = workHourEntity.OverTime,
                        User = workHourEntity.User
                    }; ;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get work hour by ID.", ex);
            }
        }

        public async Task Update(WorkHour workHour)
        {
            try
            {
                WorkHourEntity workHourDb = await _workHours.FirstOrDefaultAsync(w => w.Id == workHour.Id.ToString());
                if (workHourDb == null)
                    throw new Exception("NotFound");

                workHourDb.Project = workHour.Project;
                workHourDb.Category = workHour.Category;
                workHourDb.Description = workHour.Description;
                workHourDb.Date = workHour.Date;
                workHourDb.Time = workHour.Time;
                workHourDb.OverTime = workHour.OverTime;
                workHourDb.User = workHour.User;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update work hour.", ex);
            }
        }
    }
}
