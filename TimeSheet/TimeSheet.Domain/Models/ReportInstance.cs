using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class ReportInstance
    {
        public DateOnly Date { get; set; }
        public string TeamMember { get; set; }
        public string ProjectName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public float Time { get; set; }
    }
}
