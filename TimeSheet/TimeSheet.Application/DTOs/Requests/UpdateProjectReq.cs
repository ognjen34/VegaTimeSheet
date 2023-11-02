using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Application.DTOs.Requests
{
    public class UpdateProjectReq
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string LeadUserId { get; set; }
    }
}
