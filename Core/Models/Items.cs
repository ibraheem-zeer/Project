using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    internal class Items
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MainGroupId { get; set; }
        public int SubGroupId { get; set; }
        public int SubGroup2Id { get; set; }

        // we need to create Category and Sub-Category
        public MainGroup MainGroup { get; set; }
        public SubGroup SubGroup { get; set; }
        public SubGroup2 SubGroup2 { get; set; }

    }
}
