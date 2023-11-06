using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class UpdateWorkHourRequest
    {
        [Required]
        public string Id {  get; set; }
        public string ProjectId { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Time { get; set; }
        public float OverTime { get; set; }
        public string UserId { get; set; }
    }
}
