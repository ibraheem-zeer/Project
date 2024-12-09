﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Units
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ItemsUnits> ItemsUnits { get; set; } = new HashSet<ItemsUnits>();
    }
}
