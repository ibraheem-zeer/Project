using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double Factory { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UnitCode { get; set; }

        
        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }


        public Items Items { get; set; }
        public Invoice Invoice { get; set; }
    }
}
