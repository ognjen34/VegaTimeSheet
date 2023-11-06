using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class CreateReport
    {
        public string? UserId { get; set; }
        public string? ClientId { get; set; }
        public string? ProjectId { get; set; }
        public string? CategoryId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
