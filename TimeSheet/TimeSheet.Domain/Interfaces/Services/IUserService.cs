using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetById(Guid id);
        Task<PaginationReturnObject<User>> Search(Pagination page);
        Task Add(User user);
        Task Update(User user);
        Task Delete(Guid id);
        Task<User> Login (string username, string password);
    }
}
