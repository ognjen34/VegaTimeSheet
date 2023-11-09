﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class UpdateProjectRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClientId { get; set; }
        public string LeadId { get; set; }
        public ProjectStatus Status { get; set; }

    }
}
