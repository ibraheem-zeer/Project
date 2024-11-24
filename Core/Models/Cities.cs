using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GovermmentsId { get; set; }

        public Govermments Govermments { get; set; }
        public ICollection<Users> Users { get; set; } = new HashSet<Users>();
        public ICollection<Zones> Zones { get; set; } = new HashSet<Zones>();
    }
}
