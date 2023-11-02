using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Application.DTOs.Responses
{
    public class WorkHourRes
    {
        public string Id { get; set; }
        public Project Project { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Time { get; set; }
        public float OverTime { get; set; }
        public User User { get; set; }
    }
}
