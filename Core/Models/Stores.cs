using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Stores
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GovermmentsId { get; set; }
        public int CitiesId { get; set; }
        public int ZonesId { get; set; }

        public Govermments Govermments { get; set; }
        public Cities Cities { get; set; }
        public Zones Zones { get; set; }

        public ICollection<ItemsStores> ItemsStores { get; set; } = new HashSet<ItemsStores>();
        public ICollection<ShoppingCartItems> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItems>();
    }
}
