using API_2.Data;
using API_2.Models.Constants;
using API_2.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly DataContext _context;
        public SeedController(RoleManager<Role> roleManager, DataContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> SeedRoles()
        {
            if (_context.Roles.Any())
            {
                return Ok();
            }

            string[] roleNames =
            {
                UserRoleType.Admin,
                UserRoleType.User,
                UserRoleType.Company
            };

            IdentityResult roleResult;
            foreach(var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await _roleManager.CreateAsync(new Role
                    {
                        Name = roleName
                    });
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        } 
    }
}
