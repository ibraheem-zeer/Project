using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Users : IdentityUser<int>
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        public int GovermmentsId { get; set; }
        public int CitiesId { get; set; }
        public int ZonesId { get; set; }
        public int ClassificationsId { get; set; }

        public Govermments Govermments { get; set; }
        public Cities Cities { get; set; }
        public Zones Zones { get; set; }
        public Classifications Classifications { get; set; }
        
    }
}
