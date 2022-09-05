using API_2.Models.Constants;
using API_2.Models.Entities;
using API_2.Models.Entities.DTOs;
using API_2.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_2.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryWrapper _repo;

        public UserService(UserManager<User> userManager, IRepositoryWrapper repo)
        {
            _userManager = userManager;
            _repo = repo;
        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                user = await _repo.User.GetByIdWithRoles(user.Id);
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

                var newJti = Guid.NewGuid().ToString();

                var tokenHandler = new JwtSecurityTokenHandler();
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret key for auth"));

                var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);

                _repo.SessionToken.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repo.SaveAsync();

                return tokenHandler.WriteToken(token);
            }

            return "";
        }

        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinkey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach(var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }

        public async Task<bool> RegisteredUserClientAsync(RegisterUserDTO dto)
        {
            var user = new User();
            user.Email = dto.Email;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.UserName = dto.Email;

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoleType.User);
                return true;
            }
            return false;
        }

        public async Task<bool> RegisteredUserCompanyAsync(RegisterUserDTO dto)
        {
            var user = new User();
            user.Email = dto.Email;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.UserName = dto.Email;

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, UserRoleType.Company);
                return true;
            }
            return false;
        }
    }
}
