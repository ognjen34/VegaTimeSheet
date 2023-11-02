﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Exceptions
{
    public class ResourceNotFoundException : Exception
    {

        public ResourceNotFoundException(string message)
            : base(message)
        {
        }
    }
}