using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> Register(Users user, string password);
        Task<string> Login(string username, string password);
        Task<string> ChangePassword(string email, string oldPassword, string newPassword);
    }
}
