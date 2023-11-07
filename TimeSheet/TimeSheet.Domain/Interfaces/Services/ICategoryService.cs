using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<Category> GetById(Guid id);
        Task<PaginationReturnObject<Category>> Search(PaginationFilter page);   
        Task Add(Category category);
        Task Update(Category category);
        Task Delete(Guid guid);
    }
}
