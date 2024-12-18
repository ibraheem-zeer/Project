using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO_s
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public int Gov_Code { get; set; }
        [Required]
        public int City_Code { get; set; }
        [Required]
        public int Zone_Code { get; set; }
        [Required]
        public int Cus_ClassId { get; set; }
    }
}
