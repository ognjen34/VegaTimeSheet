using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }   
        public string Adress { get; set; }
        public string City { get; set; }
        public string Zip {  get; set; }
        public Country Country { get; set; }
        public Guid CountryId { get; set; }




    }
}
