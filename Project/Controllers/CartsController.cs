using Core.DTO_s;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Helpers;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddBulkItems(CartItemDTO cartItem)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer" , "");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("token not found");
            }
            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (!userId.HasValue) return Unauthorized("Invalid user token");
                var result = await cartRepository.AddBulkQuantity(cartItem, userId.Value);
                if(result == "Items added to cart successfully")
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch
            {
                return Unauthorized("Internal Server Error");    
            }
        }
    }
}
