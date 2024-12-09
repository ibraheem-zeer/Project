using Core.DTO_s;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /*[HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = new Users()
            {
                UserName = register.UserName,
                Email = register.Email,
                GovermmentsId = register.Gov_Code,

            };
        }*/
    }
}
