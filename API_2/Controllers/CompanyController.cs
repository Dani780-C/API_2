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
    public class CompanyController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        public CompanyController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpPost("create-company")]
        public async Task<IActionResult> CreateCompany(CreateCompanyDTO company)
        {
            Company newcomp = new Company();

            newcomp.CompanyName = company.CompanyName;
            newcomp.OwnerLastName = company.OwnerLastName;
            newcomp.OwnerFirstName = company.OwnerFirstName;
            newcomp.Type = company.Type;
           
            _repo.Company.Create(newcomp);
            await _repo.SaveAsync();

            return Ok("Company was created!");
        }

        [HttpPost("create-company-profile")]
        public async Task<IActionResult> CreateCompanyProfile(CreateCompanyProfileDTO profile)
        {

            Company comp = await _repo.Company.GetByIdAsync(profile.CompanyId);

            if (comp == null)
            {
                return BadRequest("This company does not exist in database!");
            }

            CompanyProfile exist = await _repo.CompanyProfile.GetByCompanyId(profile.CompanyId);

            if (exist != null)
            {
                return BadRequest("Company profile already exists! Update or delete it!");
            }

            CompanyProfile newprofile = new CompanyProfile();

            newprofile.Description = profile.Description;
            newprofile.Street = profile.Street;
            newprofile.City = profile.City;
            newprofile.Country = profile.Country;
            newprofile.StartDate = profile.StartDate;
            newprofile.NumberOfEmployees = profile.NumberOfEmployees;
            newprofile.CallCenterPhoneNumber = profile.CallCenterPhoneNumber;
            newprofile.CompanyId = profile.CompanyId;

            _repo.CompanyProfile.Create(newprofile);
            await _repo.SaveAsync();

            return Ok("Company profile was created!");
        }

        [HttpGet("get-all-companies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _repo.Company.GetAllCompanies();
            var companiesToReturn = new List<GetCompanyDTO>();

            foreach(var company in companies)
            {
                companiesToReturn.Add(new GetCompanyDTO(company));
            }

            return Ok(companiesToReturn);
        }
    }
}
