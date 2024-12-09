using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ItemsUnits
    {
        public int Factor {  get; set; }

        [ForeignKey(nameof(Items))]
        public int ItemId { get; set; }
        [ForeignKey(nameof(Units))]
        public int UnitId { get; set; }

        public Items Items { get; set; }
        public Units Units { get; set; }
    }
}
