using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Services
{
    public interface ICountryService
    {
        Task<Country> GetById(Guid id);
        Task<IEnumerable<Country>> GetAll();
        Task Add(Country country);
        Task Update(Country country);
        Task Delete(Country country);
    }
}
