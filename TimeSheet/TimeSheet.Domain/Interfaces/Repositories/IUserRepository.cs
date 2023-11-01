using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User project);
        Task Update(User project);
        Task Delete(string id);
    }
}
