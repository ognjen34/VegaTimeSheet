﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetById(string id);
        Task<IEnumerable<Project>> GetAll();
        Task Add(Project project);
        Task Update(Project project);
        Task Delete(string id);
    }
}