﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ShoppingCartItems
    {
        [ForeignKey("Items")]
        public int Item_Id { get; set; }

        [ForeignKey("Users")]
        public int? Cus_Id { get; set; }

        [ForeignKey("Stores")]
        public int Store_Id { get; set; }

        public double Quantity { get; set; }
        public int Unit_Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public Users Users { get; set; }
        public Stores Stores { get; set; }
        public Items Items { get; set; }
    }
}