using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Zones
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        [ForeignKey("Governments")]
        public int Gov_Id { get; set; }
        public Governments Governments { get; set; }
        
        
        [ForeignKey("Cities")]
        public int City_Id { get; set; }
        public Cities Cities { get; set; }

        public ICollection<Stores> Stores { get; set; } = new HashSet<Stores>();
        public ICollection<Users> Users { get; set; } = new HashSet<Users>();
    }
}
