using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Business.DTO
{
    public class AccountDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactLastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
