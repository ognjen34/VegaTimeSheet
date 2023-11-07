using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Data.Data;
using TimeSheet.Domain.Exceptions;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbSet<ClientEntity> _clients;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public ClientRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _clients = context.Set<ClientEntity>();
            _mapper = mapper;
        }

        public async Task Add(Client client)
        {


            ClientEntity clientEntity = _mapper.Map<ClientEntity>(client);

            await _clients.AddAsync(clientEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            ClientEntity clientDb = await _clients.FirstOrDefaultAsync(c => c.Id == id);
            if (clientDb == null)
            {
                throw new ResourceNotFoundException("Client not found");
            }

            _clients.Remove(clientDb);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginationReturnObject<Client>> Search(PaginationFilter page)
        {
            IQueryable<ClientEntity> query = _clients;

            if (!string.IsNullOrEmpty(page.StringQuery))
            {
                query = query.Where(clientEntity => clientEntity.Name.Contains(page.StringQuery));
            }

            if (!string.IsNullOrEmpty(page.FirstLetter))
            {
                query = query.Where(clientEntity => clientEntity.Name.ToLower().StartsWith(page.FirstLetter.ToLower()));
            }

            int totalCount = await query.CountAsync();


            var queryWithCountForClient = new
            {
                TotalCount = _clients.Count(), 
                Clients = query
                    .Skip((page.PageNumber - 1) * page.PageSize)
                    .Take(page.PageSize)
                    .ToList()
            };

            PaginationReturnObject<Client> clientResult = new PaginationReturnObject<Client>(
                _mapper.Map<IEnumerable<Client>>(queryWithCountForClient.Clients),
                page.PageNumber,
                page.PageSize,
                queryWithCountForClient.TotalCount
            );

            return clientResult;
        }

        public async Task<Client> GetById(string id)
        {
            ClientEntity clientEntity = await _clients.FirstOrDefaultAsync(c => c.Id == id);
            
           


            if (clientEntity != null)
            {
                return _mapper.Map<Client>(clientEntity);
            }
            else
            {
                throw new ResourceNotFoundException("Client not found");
            }
        }

        public async Task Update(Client client)
        {
            ClientEntity clientEntity = await _clients.FirstOrDefaultAsync(c => c.Id == client.Id.ToString());
            if (clientEntity == null)
            {
                throw new ResourceNotFoundException("Client not found");
            }

            _mapper.Map(client, clientEntity);
            await _context.SaveChangesAsync();
        }
    }
}
