using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ShoppingCartItems
    {
        [ForeignKey(nameof(Users))]
        public int CusId { get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        [ForeignKey(nameof(Stores))]
        public int StoreId { get; set; }

        //=========================================
        public double Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public double Factor { get; set; }
        public int UnitCode { get; set; }

        //=========================================
        public Users Users { get; set; }
        public Items Items { get; set; }
        public Stores Stores { get; set; }
    }
}