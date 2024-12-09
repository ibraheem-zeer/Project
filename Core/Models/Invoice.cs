using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Users))]
        public int CustomerId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? RecivedDate { get; set; }
        public double NetPrice { get; set; }
        public int TransactionType { get; set; }
        public int PaymentType { get; set; }
        public bool IsPosted { get; set; }
        public bool IsClosed { get; set; }
        
        public Users Users { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; } = new HashSet<InvoiceDetails>();
    }
}
