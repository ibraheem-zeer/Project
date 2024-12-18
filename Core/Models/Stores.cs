using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Stores
    {
        public int Id { get; set; }
        public string Name { get; set; }


        [ForeignKey("Governments")]
        public int Gov_Id { get; set; }
        public Governments Governments { get; set; }


        [ForeignKey("Cities")]
        public int City_Id { get; set; }
        public Cities Cities { get; set; }


        [ForeignKey(nameof(Zones))]
        public int Zone_Id { get; set; }
        public Zones Zone { get; set; }


        public ICollection<InvItemStores> InvItemStores { get; set; } = new HashSet<InvItemStores>();
        public ICollection<CustomerStores> CustomerStores { get; set; } = new HashSet<CustomerStores>();

    }
}
