using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class Report
    {
        public List<ReportInstance> ReportInstance {  get; set; }
        public Report() { 
            ReportInstance = new List<ReportInstance>();
        }
    }
}
