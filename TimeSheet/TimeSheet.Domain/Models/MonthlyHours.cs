using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class MonthlyHours
    {
        public List<WorkDay> WorkDays {  get; set; }
        public float TotalHours {  get; set; }
        public MonthlyHours() 
        {
            WorkDays = new List<WorkDay>();
        }
    }
}
