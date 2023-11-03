using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class UpdateProjectRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string LeadUserId { get; set; }
    }
}
