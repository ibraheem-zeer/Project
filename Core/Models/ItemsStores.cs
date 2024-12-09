using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ItemsStores
    {
        public double Balance { get; set; }
        public int Factor { get; set; }
        public int ReservedQuantity { get; set; }
        public DateTime LastUpdated { get; set; }

        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        [ForeignKey(nameof(Stores))]
        public int StoreId { get; set; }

        public Items Items { get; set; }
        public Stores Stores { get; set; }
    }
}
