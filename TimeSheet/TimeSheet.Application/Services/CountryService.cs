﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;
using TimeSheet.Domain.Interfaces.Repositories;
using TimeSheet.Domain.Interfaces.Services;

namespace TimeSheet.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task Add(Country country)
        {
            await _countryRepository.Add(country);
        }

        public async Task Delete(Guid id)
        {
            await _countryRepository.Delete(id.ToString());
        }

        public Task<IEnumerable<Country>> GetAll()
        {
            return _countryRepository.GetAll();
        }

        public Task<Country> GetById(Guid id)
        {
            return _countryRepository.GetById(id.ToString());
        }

        public async Task Update(Country country)
        {
            await _countryRepository.Update(country);
        }
    }
}
