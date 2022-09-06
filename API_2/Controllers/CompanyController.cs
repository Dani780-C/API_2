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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Company")]
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Company")]
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Company, User, Admin")]
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

        [HttpGet("get-all-companies_grouped-by-type")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Company, User, Admin")]
        public async Task<IActionResult> GetAllCompaniesGrouped()
        {
            var companies = await _repo.Company.GetAllAsync();
            var result = companies.GroupBy(comp => comp.Type);
            
            return Ok(result);
        }

        [HttpDelete("delete-company/{id_company}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Company, Admin")]
        public async Task<IActionResult> DeleteCompanyById(int id_company)
        {
            var company = await _repo.Company.GetCompanyById(id_company);

            if (company == null)
            {
                return NotFound("Company does not exist!");
            }

            _repo.Company.Delete(company);
            await _repo.SaveAsync();

            return NoContent();
        }

        [HttpPut("update-company/{id_company}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Company, Admin")]
        public async Task<IActionResult> UpdateCompany(int id_company, CreateCompanyDTO dto)
        {
            var comp = await _repo.Company.GetCompanyById(id_company);

            if(comp == null)
            {
                return BadRequest("Company does not exist!");
            }

            comp.CompanyName = dto.CompanyName;
            comp.OwnerFirstName = dto.OwnerFirstName;
            comp.OwnerLastName = dto.OwnerLastName;
            comp.Type = dto.Type;

            _repo.Company.Update(comp);
            await _repo.SaveAsync();

            return Ok("Company has been updated!");
        }
    }
}
