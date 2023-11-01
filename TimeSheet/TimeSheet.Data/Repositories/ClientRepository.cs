using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Data.Data;
using TimeSheet.Data.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Models;

namespace TimeSheet.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbSet<ClientEntity> _clients;
        private readonly DatabaseContex _context;

        public ClientRepository(DatabaseContex context)
        {
            _context = context;
            _clients = context.Set<ClientEntity>();
        }

        public async Task Add(Client client)
        {
            try
            {
                await _clients.AddAsync(new ClientEntity 
                {
                    Id = client.Id.ToString(), 
                    Name = client.Name,
                    Adress = client.Adress,
                    City = client.City,Zip = client.Zip,
                    Country= client.Country
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add client.", ex);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                ClientEntity clientDb = await _clients.FirstOrDefaultAsync(c => c.Id == id);
                if (clientDb == null)
                    throw new Exception("NotFound");

                _clients.Remove(clientDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete client.", ex);
            }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            try
            {
                List<ClientEntity> clients = await _clients.ToListAsync();

                List<Client> result = new List<Client>();
                foreach (ClientEntity clientEntity in clients)
                {
                    Client client = new Client
                    {
                        Id = Guid.Parse(clientEntity.Id),
                        Name = clientEntity.Name,
                        Adress = clientEntity.Adress,
                        City = clientEntity.City,
                        Zip = clientEntity.Zip,
                        Country = clientEntity.Country
                    };
                    result.Add(client);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve clients.", ex);
            }
        }

        public async Task<Client> GetById(string id)
        {
            try
            {
                ClientEntity clientEntity = await _clients.FirstOrDefaultAsync(c => c.Id == id.ToString());

                if (clientEntity != null)
                {
                    return new Client
                    {
                        Id = Guid.Parse(clientEntity.Id),
                        Name = clientEntity.Name,
                        Adress = clientEntity.Adress,
                        City = clientEntity.City,
                        Zip = clientEntity.Zip,
                        Country = clientEntity.Country
                    }; ;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get client by ID.", ex);
            }
        }

        public async Task Update(Client client)
        {
            try
            {
                ClientEntity clientDb = await _clients.FirstOrDefaultAsync(c => c.Id == client.Id.ToString());
                if (clientDb == null)
                    throw new Exception("NotFound");

                clientDb.Name = client.Name;
                clientDb.City = client.City;
                clientDb.Zip = client.Zip;
                clientDb.Country = client.Country;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update client.", ex);
            }
        }
    }
}
