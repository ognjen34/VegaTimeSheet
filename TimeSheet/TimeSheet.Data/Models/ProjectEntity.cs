using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Models
{
    public class ProjectEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ClientId {  get; set; }
        public  string LeadId {  get; set; }
        public virtual ClientEntity Client { get; set; }
        public virtual UserEntity Lead { get; set; }

    }
}
