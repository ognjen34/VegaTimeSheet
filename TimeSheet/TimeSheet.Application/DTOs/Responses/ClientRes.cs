using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Application.DTOs.Responses
{
    public class ClientRes
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public Country Country { get; set; }
    }
}
