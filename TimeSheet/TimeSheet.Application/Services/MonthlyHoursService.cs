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
        public async Task<MonthlyHours> GetUsersMontlyHours(Guid userId, DateTime startDate, DateTime endDate)
        {



            IEnumerable<WorkHour> workHours = await _workHourService.GetUsersWorkHoursForDateRange(userId, startDate, endDate);
            MonthlyHours hours = new MonthlyHours();
            var groupedWorkHours = workHours.GroupBy(x => x.Date);
            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {

                List<WorkHour> workHourForCurrentDate = workHours.Where(wh => wh.Date.Date == currentDate.Date).ToList();

                WorkDay day = new WorkDay();
                day.Date = currentDate.Day.ToString();
                day.FullDate = currentDate;

                day.Hours = workHourForCurrentDate.Count == 0 ? 0 : workHourForCurrentDate.Sum(wh => wh.Time + wh.OverTime);

                hours.WorkDays.Add(day);
                hours.TotalHours += day.Hours;
            }


            return hours;
        }
    }
}
