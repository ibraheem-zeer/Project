using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class InvItemStores
    {
        [ForeignKey("Stores")]
        public int Store_Id { get; set; }

        [ForeignKey("Items")]
        public int Item_Id { get; set; }
        public double Balance { get; set; }
        public double ReservedQuantity { get; set; }
        public int Factor { get; set; }
        public Items Items { get; set; }
        public Stores Stores { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
