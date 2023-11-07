using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetById(string id);
        Task<PaginationReturnObject<Client>> Search(PaginationFilter page);
        Task Add(Client client);
        Task Update(Client client);
        Task Delete(string id);
    }
}
