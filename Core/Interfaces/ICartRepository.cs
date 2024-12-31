using Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICartRepository
    {
        Task<string> AddBulkQuantity(CartItemDTO cartItem , int? userId);
        Task<string> AddOne(CartItemDTO cartItem , int? userId);
        Task<string> RemoveBulkQuantity(CartItemDTO cartItem , int? userId);
        Task<string> RemoveOne(CartItemDTO cartItem , int? userId);

        Task<ICollection<UserCartItemsDTO>> GetAll(int? cusId);
    }
}
