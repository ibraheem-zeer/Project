using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Helpers;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("token not found");
            }
            try
            {
                var userId = ExtractClaims.ExtractUserId(token);
                if (!userId.HasValue) return Unauthorized("Invalid user token");
                var result = await invoiceRepository.CreateInvoice(userId.Value);
                if (result.StartsWith("Invoice Number")) return Ok(result);
                return BadRequest(result);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }

        }
    }
}
