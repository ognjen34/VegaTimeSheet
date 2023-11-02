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
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryReq country)
        {
            Country response = _mapper.Map<Country>(country);
            await _countryService.Add(response);
            return Ok(_mapper.Map<CountryRes>(response));
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAllCountries()
        {
            IEnumerable<Country> countries = await _countryService.GetAll();
            IEnumerable<CountryRes> response = countries.Select(_mapper.Map<CountryRes>).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCountryById(Guid id)
        {
            Country country = await _countryService.GetById(id);
            CountryRes response = _mapper.Map<CountryRes>(country);
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
