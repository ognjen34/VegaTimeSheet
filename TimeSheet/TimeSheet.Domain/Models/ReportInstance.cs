using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class ReportInstance
    {
        public DateTime Date { get; set; }
        public string TeamMember { get; set; }
        public string ProjectName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public float Time { get; set; }
        public override string ToString() 
        {
            return $"Date: {Date.ToString()} Worker: {TeamMember} Client: {ProjectName} Category: {CategoryName} Time: {Time}";
        }

    }
}
