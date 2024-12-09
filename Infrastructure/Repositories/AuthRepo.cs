using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthRepo : IAuthRepo
    {
        private readonly UserManager<Users> userManager;

        public AuthRepo(UserManager<Users> userManager)
        {
            this.userManager = userManager;
        }

        public Task<string> ChangePassword(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(Users users, string password)
        {
            var res = await userManager.CreateAsync(users, password);
            if (!res.Succeeded) return string.Join(",",res.Errors.Select(e => e.Description).ToList());
            return "User Registerd Successfully";
        }
    }
}
