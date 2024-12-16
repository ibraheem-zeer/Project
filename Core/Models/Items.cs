﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double price { get; set; }

        [ForeignKey(nameof(MainGroup))]
        public int MG_Id { get; set; }

        [ForeignKey(nameof(SubGroup))]
        public int Sub_Id { get; set; }


        [ForeignKey(nameof(SubGroup2))]

        public int Sub2_Id { get; set; }

        public MainGroup MainGroup { get; set; }
        public SubGroup SubGroup { get; set; }
        public SubGroup2 SubGroup2 { get; set; }
        public ICollection<InvItemStores> InvItemStores { get; set; }
        public ICollection<ItemsUnits> ItemsUnits { get; set; } = new HashSet<ItemsUnits>();

    }
}
