using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<Client> GetById(Guid id);
        Task<IEnumerable<Client>> GetAll();
        Task Add(Client client);
        Task Update(Client client);
        Task Delete(Guid id);
    }
}
