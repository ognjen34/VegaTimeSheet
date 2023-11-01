using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> GetById(string id);
        Task<IEnumerable<Country>> GetAll();
        Task Add(Country country);
        Task Update(Country country);
        Task Delete(string id);
    }
}
