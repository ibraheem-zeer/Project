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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext context;

        public InvoiceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<string> CreateInvoice(int cusId)
        {
            var carItems = await context.ShoppingCartItems.Include(x => x.Items).Where(c => c.Cus_Id == cusId).ToListAsync();
            if (carItems == null || !carItems.Any()) return "No items in the cart";

            var unavailableItems = new List<string>();
            double totalNetPrice = 0;
            foreach(var item in carItems)
            {
                var itemStore = await context.InvItemStores.FirstOrDefaultAsync(i => i.Item_Id == item.Item_Id && i.Store_Id == item.Store_Id);
                if(itemStore == null)
                {
                    unavailableItems.Add(item.Items.Name);
                    continue;
                }
                double avl = itemStore.Balance - itemStore.ReservedQuantity;
                if (item.Quantity > avl)
                {
                    unavailableItems.Add(item.Items.Name);
                    continue;
                }
            }

            var unvCount = unavailableItems.Count();
            var numCartItems = carItems.Count();
            if (unvCount == numCartItems) return "All items in cart Unavailable";

            Invoice invoice = new Invoice()
            {
                Cus_Id = cusId,
                CreatedAt = DateTime.Now,
                NetPrice = 0,
                Transaction_Type = 1,
                Payment_Type = 1,
                isPosted = true,
                isClosed = false,
                isReviewed = false,
            };
            await context.Invoice.AddAsync(invoice);

            foreach(var item in carItems)
            {

                var itemStore = await context.InvItemStores.FirstOrDefaultAsync(i => i.Item_Id == item.Item_Id && i.Store_Id == item.Store_Id);

                double unitPrice = item.Items.price;
                double total = item.Quantity * unitPrice;
                totalNetPrice += total;

                InvoiceDetails invoiceDetails = new InvoiceDetails()
                {
                    Invoice_Id = invoice.Id,
                    Item_Id = item.Item_Id,
                    Quantity = item.Quantity,
                    CreatedAt = DateTime.Now,
                    Factor = 1,
                    price = (int)unitPrice,
                    Unit_Id = item.Unit_Id,
                };
                await context.InvoiceDetails.AddAsync(invoiceDetails);

                itemStore.ReservedQuantity = item.Quantity;
                context.InvItemStores.Update(itemStore);
            }
            invoice.NetPrice = totalNetPrice;

            context.ShoppingCartItems.RemoveRange(carItems.Where(i => !unavailableItems.Contains(i.Items.Name)));
            await context.SaveChangesAsync();

            if (unavailableItems.Any())
            {
                var unMessage = string.Join(",", unavailableItems.Select(async item =>
                {
                    var cart = carItems.FirstOrDefault(i => i.Items.Name == item);
                    if(cart != null)
                    {
                        var itemStore = await context.InvItemStores.FirstOrDefaultAsync(i => i.Item_Id == cart.Item_Id);
                        if(itemStore != null)
                        {
                            double avlQuantity = itemStore.Balance = itemStore.ReservedQuantity;
                            return $"the Available Quantity of {item} is : {avlQuantity}";
                        }
                    }
                    return item;
                }));
                return $"Invoice Number : {invoice.Id} and total Price {totalNetPrice} , and the following items are not available right now {unMessage}";
            }
            return $"Invoice Number : {invoice.Id} and total Price {totalNetPrice}";
        }

        public async Task<InvoiceRecieptDTO> GetInvoiceRecipt(int cusId, int invId)
        {
            var invoice = await context.Invoice
                .Include(i => i.Details)
                .ThenInclude(it => it.Items)
                .FirstOrDefaultAsync(i => i.Cus_Id == cusId && i.Id == invId);

            if (invoice == null) return null;
            double totalPrice = 0;
            foreach(var item in invoice.Details)
            {
                double itemPrice = item.Quantity * item.price;
                totalPrice += itemPrice;                
            }

            invoice.NetPrice = totalPrice;
            await context.SaveChangesAsync();
            var reciept = new InvoiceRecieptDTO
            {
                InvoiceId = invoice.Id,
                CusId = cusId,
                CreatedAt = DateTime.Now,
                TotalPrice = totalPrice,
                Items = await Task.WhenAll(invoice.Details.Select(async si => new InvoiceItemsDTO
                {
                    ItemName = si.Items.Name,
                    PricePerUnit = si.Items.price,
                    UnitName = (await context.Units.FirstOrDefaultAsync(u => u.Id == si.Unit_Id))?.Name ?? "Unknown",
                    Quantity = si.Quantity,
                    TotalPrice = si.Quantity * si.price
                }))

            };
            return reciept;
        }
    }
}
