using Core.DTO_s;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly AppDbContext context;

        public ItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ItemsDTO>> GetItems() => await context.Items
            .Include(i => i.ItemsUnits)
            .Select(x => new ItemsDTO
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.price,
                ItemUnits = x.ItemsUnits.Select(iu => iu.Units.Name).ToList(),
                Stores = x.InvItemStores.Select(st => st.Stores.Name).ToList(),
            })
            .ToListAsync();


    }
}
