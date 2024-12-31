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

        [HttpPost("add_to_cart")]
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

        
        [HttpPost("add_One_to_cart")]
        public async Task<IActionResult> AddOneItem(CartItemDTO cartItem)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token)) return Unauthorized("Token not found");
            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (!userId.HasValue) return Unauthorized("Invalid user token");
                var result = await cartRepository.AddOne(cartItem, userId.Value);
                if (result == "Done") return Ok(result);
                return BadRequest(result);
            }
            catch
            {
                return StatusCode(500, "Internal server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token)) return Unauthorized("token not found");
            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (!userId.HasValue) return Unauthorized("Invalid user token");
                var result = await cartRepository.GetAll(userId.Value);
                if(result == null) return NotFound("The cart is Empty");
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex.Message}");
            }

        }
    }
}
