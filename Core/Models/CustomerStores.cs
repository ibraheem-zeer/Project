using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CustomerStores
    {
        public bool IsDefault { get; set; }
        
        [ForeignKey(nameof(Users))]
        public int CustomerId { get; set; }
            
        [ForeignKey(nameof(Stores))]
        public int StoreId { get; set; }
        
        public Users Users { get; set; }
        public Stores Stores { get; set; }
    }
}
