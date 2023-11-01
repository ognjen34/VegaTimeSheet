using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Application.DTOs.Responses
{
    public class CreateUserRes
    {
        public CreateUserRes() { }
        public CreateUserRes(User user) 
        {
            this.Role = user.Role;
            this.Id = user.Id;
            this.Email = user.Email;
            this.Role = user.Role;
            this.Name = user.Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }

    
}
