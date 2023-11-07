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
        Task<PaginationReturnObject<User>> Search(Pagination page);
        Task Add(User project);
        Task Update(User project);
        Task Delete(string id);
        Task<User> GetByEmailAndPassword(string email,string password);
    }
}
