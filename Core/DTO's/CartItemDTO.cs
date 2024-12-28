using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO_s
{
    public class CartItemDTO
    {
        public int ItemCode { get; set; }
        public double Quantity { get; set; }
        public int UnitCode { get; set; }
        public int StoreId { get; set; }
    }
}
