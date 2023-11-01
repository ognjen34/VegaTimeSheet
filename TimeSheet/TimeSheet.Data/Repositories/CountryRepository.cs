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
    public class CountryRepository : ICountryRepository
    {
        private readonly DbSet<CountryEntity> _countries;
        private readonly DatabaseContex _context;

        public CountryRepository(DatabaseContex context)
        {
            _context = context;
            _countries = context.Set<CountryEntity>();
        }

        public async Task Add(Country country)
        {
            try
            {
                await _countries.AddAsync(new CountryEntity { Id = country.Id.ToString(), Name = country.Name });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add country.", ex);
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                CountryEntity countryDb = await _countries.FirstOrDefaultAsync(p => p.Id == id);
                if (countryDb == null)
                    throw new Exception("NotFound");

                _countries.Remove(countryDb);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete country.", ex);
            }
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            try
            {
                List<CountryEntity> countries = await _countries.ToListAsync();

                List<Country> result = new List<Country>();
                foreach (CountryEntity countryEntity in countries)
                {
                    Country country = new Country() { Id = Guid.Parse(countryEntity.Id), Name = countryEntity.Name };
                    result.Add(country);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve countries.", ex);
            }
        }

        public async Task<Country> GetById(string id)
        {
            try
            {
                CountryEntity countryDb = await _countries.FirstOrDefaultAsync(p => p.Id == id);

                if (countryDb != null)
                {
                    return new Country { Id = Guid.Parse(countryDb.Id), Name = countryDb.Name };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get country by ID.", ex);
            }
        }

        public async Task Update(Country country)
        {
            try
            {
                CountryEntity countryDb = await _countries.FirstOrDefaultAsync(p => p.Id == country.Id.ToString());
                if (countryDb == null)
                    throw new Exception("NotFound");

                countryDb.Name = country.Name;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update country.", ex);
            }
        }
    }
}
