using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO_s
{
    public class InvoiceRecieptDTO
    {
        [DisplayName("Invoice Number")]
        public int InvoiceId { get; set; }

        [DisplayName("Customer Id")]
        public int CusId { get; set; }

        public double TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<InvoiceItemsDTO> Items { get; set; }
    }
}
