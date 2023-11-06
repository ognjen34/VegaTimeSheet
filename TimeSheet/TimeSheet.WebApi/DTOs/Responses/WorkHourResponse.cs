using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.WebApi.DTOs.Responses
{
    public class WorkHourResponse
    {
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Time { get; set; }
        public float OverTime { get; set; }
        public string UserName { get; set; }
    }
}
