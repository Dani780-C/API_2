using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_2.Data;
using API_2.Models.Entities;
using API_2.Repositories;
using API_2.Models.Entities.DTOs;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public ServicesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        
        [HttpGet("get-all-services")]
        public async Task<IActionResult> GetAllServices()
        {

            var services = await _repo.Service.GetAllServices();
            var toReturn = new List<GetServiceDTO>();

            foreach(var service in services)
            {
                toReturn.Add(new GetServiceDTO(service));
            }

            return Ok(toReturn);
            
        }

        [HttpPost("create-service")]
        public async Task<ActionResult<Service>> CreateService(CreateServiceDTO service)
        {

            Company comp = await _repo.Company.GetCompanyById(service.CompanyId);

            if(comp == null)
            {
                return BadRequest("The service cannot be added beacause the company does not exist!");
            }

            Service srv = new Service();
            srv.ServiceName = service.ServiceName;
            srv.Price = service.Price;
            srv.Description = service.Description;
            srv.PhoneNumber = service.PhoneNumber;
            srv.Email = service.Email;
            srv.Guarantee = service.Guarantee;
            srv.CompanyId = service.CompanyId;


            _repo.Service.Create(srv);
            await _repo.SaveAsync();

            return Ok("The service was added!");
        }

        [HttpPost("call-service")]
        public async Task<IActionResult> CallService(CallServiceDTO dto)
        {

            Service service = await _repo.Service.GetServiceById(dto.ServiceId);
            Client client = await _repo.Client.GetClientById(dto.ClientId);

            if (service == null || client == null)
            {
                return BadRequest("Client or service does not exist!");
            }

            ClientService cs = new ClientService();
            cs.ClientId = dto.ClientId;
            cs.ServiceId = dto.ServiceId;

            _repo.ClientService.Create(cs);
            await _repo.SaveAsync();

            return Ok("The requested service was called!");
        }

        [HttpGet("get-all-services-by-clientid/{id_client}")]
        public async Task<IActionResult> GetServicesForAClient(int id_client)
        {
            Client client = await _repo.Client.GetClientById(id_client);

            if (client == null)
            {
                return BadRequest("Client does not exist!");
            }

            var services = await _repo.Service.GetAllServicesByIdClient(id_client);
            List<GetServiceForCompanyDTO> toReturn = new List<GetServiceForCompanyDTO>();

            foreach(var service in services)
            {
                toReturn.Add(new GetServiceForCompanyDTO(service));
            }

            return Ok(toReturn);
        }
    }
}
