using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Application.DTOs.Responses
{
    public class ProjectRes
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Client Client { get; set; }
        public User Lead { get; set; }
    }
}
