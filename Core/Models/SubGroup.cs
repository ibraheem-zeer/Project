using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    internal class SubGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MainGroupId { get; set; }

        public MainGroup MainGroup { get; set; }
        public ICollection<Items> Items { get; set; } = new HashSet<Items>();
        public ICollection<SubGroup2> SubGroups2 { get; set; } = new HashSet<SubGroup2>();
    }
}
