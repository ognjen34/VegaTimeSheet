using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(string id);
        Task Add(Category category);
        Task Update(Category category);
        Task Delete(string id);
        Task<PaginationReturnObject<Category>> Search(PaginationFilter page);

    }
}
