using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class WorkDay
    {
        public string Date {  get; set; }
        public float Hours {  get; set; }
        public DateTime FullDate { get; set; }
        public Boolean Flag {  get; set; }

    }
}
