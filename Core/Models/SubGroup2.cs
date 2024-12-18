using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SubGroup2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Items> Items { get; set; } = new HashSet<Items>();


        [ForeignKey("MainGroup")]
        public int MG_Id { get; set; }
        public MainGroup MainGroup { get; set; }
        
        
        [ForeignKey("SubGroup")]
        public int Sub_Id { get; set; }
        public SubGroup SubGroup { get; set; }
    }
}
