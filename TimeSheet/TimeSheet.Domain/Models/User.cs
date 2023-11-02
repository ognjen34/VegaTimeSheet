using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
        public float WorkingHours { get; set; }
    }

    public enum Status { Inactive,Active}
    public enum Role {Admin,Worker }
}
