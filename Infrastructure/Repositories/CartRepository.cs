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

        public async Task<string> AddBulkQuantity(CartItemDTO cartItem, int? userId)
        {
            var item = await context.Items.FindAsync(cartItem.ItemCode);
            var store = await context.Stores.FindAsync(cartItem.StoreId);
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

        public async Task<string> AddOne(CartItemDTO cartItem, int? userId)
        {
            var item = await context.Items.FindAsync(cartItem.ItemCode);
            var store = await context.Stores.FindAsync(cartItem.StoreId);

            if (item == null || store == null) return "item or store are Empty";

            var existingItem = await context.ShoppingCartItems.FirstOrDefaultAsync(cart => cart.Item_Id == cartItem.ItemCode && cart.Store_Id== cartItem.StoreId);

            if(existingItem != null)
            {
                existingItem.Quantity += 1;
                existingItem.Unit_Id = cartItem.UnitCode;
                existingItem.Store_Id = cartItem.StoreId;
                existingItem.UpdatedAt = DateTime.Now;
            }
            else
            {
                ShoppingCartItems shoppingCartItem = new ShoppingCartItems()
                {
                    Cus_Id = userId,
                    Item_Id = cartItem.ItemCode,
                    Quantity = 1,
                    Unit_Id = cartItem.UnitCode,
                    Store_Id = cartItem.StoreId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null
                };
                await context.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            await context.SaveChangesAsync();
            return "Done";
        }

        public async Task<ICollection<UserCartItemsDTO>> GetAll(int? cusId)
        {
            var cartItems = await context.ShoppingCartItems.Where(x => x.Cus_Id == cusId)
                .Include(x => x.Items)
                .Include(x => x.Items.ItemsUnits)
                .ThenInclude(x => x.Units)
                .ToListAsync();

            var item = cartItems.Select(x => new UserCartItemsDTO
            {
                Name = x.Items.Name,
                Price = x.Items.price,
                Quantity = x.Quantity,
                ItemUnit = x.Items.ItemsUnits.Where(u => u.Unit_Id == x.Unit_Id && u.Item_Id == x.Item_Id).Select(unit => unit.Units.Name).FirstOrDefault()!,
            }).ToList();
            return item;
        }

        public Task<string> RemoveBulkQuantity(CartItemDTO cartItem, int? userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveOne(CartItemDTO cartItem, int? userId)
        {
            throw new NotImplementedException();
        }
    }
}