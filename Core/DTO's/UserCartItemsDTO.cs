using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO_s
{
    public class UserCartItemsDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ItemUnit { get; set; }
        public double Quantity { get; set; }
    }
}
