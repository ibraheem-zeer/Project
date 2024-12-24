using Core.DTO_s;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository itemsRepository;

        public ItemsController(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ItemsDTO>>> GetItems()
        {
            var items = await itemsRepository.GetItems();
            if(items is not null ) return Ok(items);
            return NotFound("items not found");
        }
    }
}
