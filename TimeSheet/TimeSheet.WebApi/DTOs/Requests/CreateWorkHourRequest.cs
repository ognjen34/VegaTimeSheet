using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class CreateWorkHourRequest
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Time { get; set; }
        [Required]
        public float Overtime { get; set; }
    }
}
