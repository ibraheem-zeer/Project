using Core.DTO_s;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = new Users()
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                Gov_Id = registerDTO.Gov_Code,
                City_Id = registerDTO.City_Code,
                Zone_Id = registerDTO.Zone_Code,
                Class_Id = registerDTO.Cus_ClassId
            };
            var res = await authRepository.Register(user, registerDTO.Password);
            return Ok(res);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                var token = await authRepository.Login(loginDTO.UserName, loginDTO.Password);
                if(token == null) return Unauthorized(new {Message = "Invalid Username or Passwrod" });
                return Ok(token);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { Message = "Internal Server Error" });
            }
        }

    }
}
