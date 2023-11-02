using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class UpdateWorkHourReq
    {
        public string Id {  get; set; }
        public string ProjectId { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public float Time { get; set; }
        public float OverTime { get; set; }
        public string UserId { get; set; }
    }
}
