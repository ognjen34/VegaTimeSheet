using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.WebApi.DTOs.Requests;
using TimeSheet.WebApi.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace TimeSheet.WebApi.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService, IMapper mapper) : base(mapper)
        {
            _countryService = countryService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryRequest country)
        {
            Country response = _mapper.Map<Country>(country);
            await _countryService.Add(response);
            return Ok(_mapper.Map<CountryResponse>(response));
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllCountries()
        {
            IEnumerable<Country> countries = await _countryService.GetAll();
            IEnumerable<CountryResponse> response = countries.Select(_mapper.Map<CountryResponse>).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCountryById(Guid id)
        {
            Country country = await _countryService.GetById(id);
            CountryResponse response = _mapper.Map<CountryResponse>(country);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(Guid id)
        {
            await _countryService.Delete(id);
            return Ok("Country Deleted!");
        }
    }
}
