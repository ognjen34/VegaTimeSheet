using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Interfaces.Services;
using TimeSheet.Domain.Models;
using TimeSheet.Application.DTOs.Requests;
using TimeSheet.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

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
            await _clientService.Add(response);
            return Ok(_mapper.Map<ClientRes>(response));
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientReq updatedClient)
        {
            Client client = _mapper.Map<Client>(updatedClient);
            await _clientService.Update(client);
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
            Client client = await _clientService.GetById(id);
            ClientRes response = _mapper.Map<ClientRes>(client);
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
