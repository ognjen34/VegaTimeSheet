using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Application.DTOs.Responses
{
    public class UserRes
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }

    
}
