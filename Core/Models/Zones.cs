using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Zones
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CitiesId { get; set; }
        public int GovermmentsId { get; set; }

        public ICollection<Users> Users { get; set; } = new HashSet<Users>();
        public Govermments Govermments { get; set; }
        public Cities Cities { get; set; }
    }
}
