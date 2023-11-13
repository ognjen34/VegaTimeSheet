using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Services
{
    public interface IMonthlyHoursService
    {
        Task<MonthlyHours> GetUsersMontlyHours(Guid userId, DateTime startDate,DateTime endDate);
        
    }
}
