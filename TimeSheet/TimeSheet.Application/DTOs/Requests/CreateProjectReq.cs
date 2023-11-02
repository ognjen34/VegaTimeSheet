using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Application.DTOs.Requests
{
    public class CreateProjectReq
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string LeadUserId { get; set; }
    }
}
