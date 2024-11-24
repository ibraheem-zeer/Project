using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Users : IdentityUser
    {
        public int GovermmentsId { get; set; }
        public int CitiesId { get; set; }
        public int ZonesId { get; set; }

        public Govermments Govermments { get; set; }
        public Cities Cities { get; set; }
        public Zones Zones { get; set; }
    }
}
