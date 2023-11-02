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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientReq client)
        {
            Client response = _mapper.Map<Client>(client);
            try
            {
                await _clientService.Add(response);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

            return Ok(_mapper.Map<ClientRes>(response));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientReq updatedClient)
        {
            Client client = _mapper.Map<Client>(updatedClient);
            try
            {
                await _clientService.Update(client);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

            return Ok("Client Updated!");
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetAllClients()
        {
            IEnumerable<Client> clients = await _clientService.GetAll();

            IEnumerable<ClientRes> response = clients.Select(_mapper.Map<ClientRes>).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientById(Guid id)
        {
            try
            {
                Client client = await _clientService.GetById(id);
                ClientRes response = _mapper.Map<ClientRes>(client);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(Guid id)
        {
            try
            {
                await _clientService.Delete(id);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
            return Ok("Client Deleted!");
        }
    }
}
