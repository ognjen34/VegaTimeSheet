using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class CreateWorkHourRequest
    {
        public string ProjectId { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public float Time { get; set; }
        public float OverTime { get; set; }
        public string UserId { get; set; }
    }
}
