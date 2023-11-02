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
    public class CountryRepository : ICountryRepository
    {
        private readonly DbSet<CountryEntity> _countries;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _countries = context.Set<CountryEntity>();
            _mapper = mapper;
        }

        public async Task Add(Country country)
        {
            CountryEntity countryEntity = _mapper.Map<CountryEntity>(country);
            await _countries.AddAsync(countryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            CountryEntity countryDb = await _countries.FirstOrDefaultAsync(c => c.Id == id);
            if (countryDb == null)
            {
                throw new ResourceNotFoundException("Country not found");
            }

            _countries.Remove(countryDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            List<CountryEntity> countryEntities = await _countries.ToListAsync();
            List<Country> result = countryEntities.Select(countryEntity => _mapper.Map<Country>(countryEntity)).ToList();

            return result;
        }

        public async Task<Country> GetById(string id)
        {
            CountryEntity countryEntity = await _countries.FirstOrDefaultAsync(c => c.Id == id);

            if (countryEntity != null)
            {
                return _mapper.Map<Country>(countryEntity);
            }
            else
            {
                throw new ResourceNotFoundException("Country not found");
            }
        }

        public async Task Update(Country country)
        {
            CountryEntity countryEntity = await _countries.FirstOrDefaultAsync(c => c.Id == country.Id.ToString());
            if (countryEntity == null)
            {
                throw new ResourceNotFoundException("Country not found");
            }

            countryEntity.Name = country.Name;
            await _context.SaveChangesAsync();
        }
    }
}
