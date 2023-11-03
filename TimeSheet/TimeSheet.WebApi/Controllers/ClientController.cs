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
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest client)
        {
            Client response = _mapper.Map<Client>(client);
            await _clientService.Add(response);
            return Ok(_mapper.Map<ClientResponse>(response));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest updatedClient)
        {
            Client client = _mapper.Map<Client>(updatedClient);
            await _clientService.Update(client);
            return Ok("Client Updated!");
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllClients()
        {
            IEnumerable<Client> clients = await _clientService.GetAll();
            IEnumerable<ClientResponse> response = clients.Select(_mapper.Map<ClientResponse>).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientById(Guid id)
        {
            Client client = await _clientService.GetById(id);
            ClientResponse response = _mapper.Map<ClientResponse>(client);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(Guid id)
        {
            await _clientService.Delete(id);
            return Ok("Client Deleted!");
        }
    }
}
