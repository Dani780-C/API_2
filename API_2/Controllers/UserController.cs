using API_2.Models.Entities.DTOs;
using API_2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;

        public UserController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repo.User.GetAllUsers();
            var userToReturn = new List<GetUserDTO>();

            foreach(var user in users)
            {
                userToReturn.Add(new GetUserDTO(user));
            }

            return Ok(userToReturn);
        }
    }
}
