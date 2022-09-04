using API_2.Models.Entities;
using API_2.Models.Entities.DTOs;
using API_2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        public ClientController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet("get-all-clients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _repo.Client.GetAllClientsWithData();

            var clientsToReturn = new List<ClientDataDTO>();

            foreach (var client in clients)
            {
                clientsToReturn.Add(new ClientDataDTO(client));
            }
            return Ok(clientsToReturn);
        }

        [HttpGet("get-all-clients-with-services")]
        public async Task<IActionResult> GetAllClientsWithServices()
        {
            var clients = await _repo.Client.GetAllClientsWithServices();

            var clientsToReturn = new List<ClientDTO>();

            foreach (var client in clients)
            {
                
                clientsToReturn.Add(new ClientDTO(client));
            }
            return Ok(clientsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientDTO dto)
        {
            Client client = new Client();

            var exist = await _repo.Client.GetClientByEmail(dto.Email);

            if(exist != null)
            {
                return BadRequest("Client already exists!");
            }

            client.FirstName = dto.FirstName;
            client.LastName = dto.LastName;
            client.Email = dto.Email;
            client.PhoneNumber = dto.PhoneNumber;

            _repo.Client.Create(client);
            await _repo.SaveAsync();

            return Ok("New client added!");
        }

        [HttpGet("get-client-by-id/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _repo.Client.GetClientDataById(id);

            if(client.Count == 0)
            {
                return NoContent();
            }
            
            return Ok(new ClientDTO(client[0]));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientById(int id)
        {
            var client = await _repo.Client.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound("Client does not exist!");
            }

            _repo.Client.Delete(client);
            await _repo.SaveAsync();

            return NoContent();
        }
    }
}
