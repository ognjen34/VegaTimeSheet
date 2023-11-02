using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;

namespace TimeSheet.Application.Services
{
    public class MonthlyHoursService : IMonthlyHoursService
    {
        private readonly IWorkHourService _workHourService;

        public MonthlyHoursService(IWorkHourService workHourService)
        {
            _workHourService = workHourService;
        }
        public async Task<MonthlyHours> GetUsersMontlyHours(Guid userId,DateOnly startDate,DateOnly endDate) 
        {

          

            IEnumerable<WorkHour> workHours = await _workHourService.GetUsersWorkHoursForDateRange(userId, startDate,endDate);
            MonthlyHours hours = new MonthlyHours();

            for (DateOnly currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {

                List<WorkHour> workHourForCurrentDate = workHours.Where(wh => wh.Date == currentDate).ToList();

                WorkDay day = new WorkDay();
                day.Date = currentDate;

                if (workHourForCurrentDate.Count == 0) day.Hours = 0;
                else day.Hours = workHourForCurrentDate.Sum(wh => wh.Time + wh.OverTime); 

                hours.WorkDays.Add(day);
                hours.TotalHours += day.Hours;
            }

            
            return hours;
        }
    }
}
