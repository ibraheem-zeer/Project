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
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext context;

        public CartRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddBulkQuantity(CartItemDTO cartItem, int userId)
        {
            var item = await context.Items.FindAsync(cartItem.ItemCode);
            var store = await context.Items.FindAsync(cartItem.StoreId);
            if (item == null || store == null) return "Item or store not found!";

            var itemExist = await context.ShoppingCartItems.FirstOrDefaultAsync(x => x.Cus_Id == userId && x.Item_Id == cartItem.ItemCode && x.Store_Id == cartItem.StoreId);

            if(itemExist != null)
            {
                itemExist.Quantity += cartItem.Quantity;
                itemExist.Unit_Id = cartItem.UnitCode;
                itemExist.Store_Id = cartItem.StoreId;
                itemExist.UpdatedAt = DateTime.Now;
            }
            else
            {
                var shoppingCartItems = new ShoppingCartItems()
                {
                    Cus_Id = userId,
                    Item_Id = cartItem.ItemCode,
                    Quantity = cartItem.Quantity,
                    Unit_Id = cartItem.UnitCode,
                    Store_Id = cartItem.StoreId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null,
                };
                await context.ShoppingCartItems.AddAsync(shoppingCartItems);
            }
            await context.SaveChangesAsync();
            return "Items added to cart successfully";
        }

        public Task<string> AddOne(CartItemDTO cartItem, int userId)
        {
            throw new NotImplementedException();
        }
    }
}