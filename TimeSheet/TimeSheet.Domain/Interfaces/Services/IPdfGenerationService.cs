﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Strategy;

namespace TimeSheet.Domain.Interfaces.Services
{
    public interface IPdfGenerationService
    {
        public byte[] GeneratePdf<T>(IPdfGenerationStrategy<T> strategy);

    }
}
