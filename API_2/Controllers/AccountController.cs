using API_2.Models.Constants;
using API_2.Models.Entities;
using API_2.Models.Entities.DTOs;
using API_2.Repositories;
using API_2.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IRepositoryWrapper _repo;

        public AccountController(UserManager<User> userManager, IUserService userService, IRepositoryWrapper repo)
        {
            _userManager = userManager;
            _userService = userService;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {
            var exists = await _userManager.FindByEmailAsync(dto.Email);

            if(exists != null)
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisteredUserAsync(dto);

            if(result == true)
            {
                return Ok(result);
            }
            
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);

            if(token == "")
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }

        [HttpGet("get-all-session-tokens")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> GetAllTokens()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var tokens = _repo.SessionToken.GetAll();
            return Ok(tokens);
        }

        [HttpDelete("delete-token")]
        public async Task<IActionResult> DeleteToken()
        {
            var tokens = _repo.SessionToken.GetAll();
            _repo.SessionToken.DeleteRange(tokens);
            await _repo.SaveAsync();
            return Ok("All deleted!");
        }
    }
}
