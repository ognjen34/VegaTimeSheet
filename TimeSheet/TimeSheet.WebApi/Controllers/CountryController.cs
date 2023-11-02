using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.Application.DTOs.Requests;
using TimeSheet.Application.DTOs.Responses;
using TimeSheet.Domain.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization; // If you need authorization attributes

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
            try
            {
                await _countryService.Add(response);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return BadRequest(ex.Message);
            }

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
            try
            {
                Country country = await _countryService.GetById(id);
                CountryRes response = _mapper.Map<CountryRes>(country);
                return Ok(response);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(Guid id)
        {
            try
            {
                await _countryService.Delete(id);
            }
            catch (Exception ex) // Handle specific exceptions here
            {
                return NotFound(ex.Message);
            }
            return Ok("Country Deleted!");
        }
    }
}
