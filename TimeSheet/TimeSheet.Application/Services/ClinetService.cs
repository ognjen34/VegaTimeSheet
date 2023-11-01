using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;

namespace TimeSheet.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Add(Client client)
        {
            _clientRepository.Add(client);
        }

        public async Task Delete(Client client)
        {
            _clientRepository.Delete(client.Id.ToString());
        }

        public Task<IEnumerable<Client>> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public Task<Client> GetById(Guid id)
        {
            return _clientRepository.GetById(id.ToString());
        }

        public async Task Update(Client client)
        {
            _clientRepository.Update(client);
        }
    }
}
