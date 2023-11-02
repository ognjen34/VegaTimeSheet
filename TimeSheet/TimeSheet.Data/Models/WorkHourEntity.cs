using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Models
{
    public class WorkHourEntity
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Time { get; set; }
        public float OverTime { get; set; }
        public string UserId {  get; set; }
        public string ProjectId { get; set; }
        public string CategoryId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ProjectEntity Project { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
