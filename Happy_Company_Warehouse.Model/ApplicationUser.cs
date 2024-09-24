using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Company_Warehouse.Model
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Role { get; set; } 
        
        public string? TenantId { get; set; }
        [Required]

        public bool Active { get; set; }=true;
    }
}
