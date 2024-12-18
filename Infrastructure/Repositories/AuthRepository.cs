using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly IConfiguration configuration;

        public AuthRepository(UserManager<Users> userManager , SignInManager<Users> signInManager , IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<string> Register(Users user, string password)
        {
            var res = await userManager.CreateAsync(user , password);
            if (!res.Succeeded) return string.Join(",",res.Errors.Select(e => e.Description).ToList());
            return "User Registered Successfully";
        }

        public Task<string> ChangePassword(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user is null) return "Invalid Username or Passwrod";
            // is Persistent as Remember me
            // LockOnFaliure , to lock the account after some try
            var res = await signInManager.PasswordSignInAsync(user , password , false , false);
            if (!res.Succeeded) return null!;
            return GenerateToken(user);
        }


        private string GenerateToken(Users user)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub , user.UserName),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: configuration.GetSection("Keys")["aud"],
                issuer: configuration.GetSection("Keys")["issuer"],
                claims: authClaims,
                signingCredentials: credential,
                expires: DateTime.UtcNow.AddMinutes(45)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
