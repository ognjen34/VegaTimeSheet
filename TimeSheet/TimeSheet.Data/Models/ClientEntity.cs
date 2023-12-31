﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Models
{
    public class ClientEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public  virtual CountryEntity Country { get; set; }
        public string CountryId {  get; set; }
    }
}
