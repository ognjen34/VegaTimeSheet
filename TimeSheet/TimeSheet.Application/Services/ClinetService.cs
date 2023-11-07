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
        private readonly ICountryService _countryService;


        public ClientService(IClientRepository clientRepository , ICountryService countryService)
        {
            _clientRepository = clientRepository;
            _countryService = countryService;
        }

        public async Task Add(Client client)
        {
            await _clientRepository.Add(client);
        }

        public async Task Delete(Guid id)
        {
            await _clientRepository.Delete(id.ToString());
        }

        public Task<PaginationReturnObject<Client>> Search(PaginationFilter page)
        {
            return _clientRepository.Search(page);
        }

        public Task<Client> GetById(Guid id)
        {
            return _clientRepository.GetById(id.ToString());
        }

        public async Task Update(Client client)
        {
            await _clientRepository.Update(client);
        }
    }
}
