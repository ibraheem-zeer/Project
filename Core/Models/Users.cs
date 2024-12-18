using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Users : IdentityUser<int>
    {
        [ForeignKey("Governments")]
        public int Gov_Id { get; set; }

        [ForeignKey("Cities")]
        public int City_Id { get; set; }

        [ForeignKey("Zones")]
        public int Zone_Id { get; set; }

        [ForeignKey("Classifications")]
        public int Class_Id { get; set; }

        public Classifications Classifications { get; set; }
        public Zones Zones { get; set; }

        public Governments Governments { get; set; }
        public Cities Cities { get; set; }
        public ICollection<CustomerStores> CustomerStores { get; set; } = new HashSet<CustomerStores>();
    }
}

/*
Introducing FOREIGN KEY constraint 'FK_AspNetUsers_Governments_Gov_Id' on table 'AspNetUsers' may cause cycles or multiple cascade paths.
Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
Could not create constraint or index. See previous errors. 
*/