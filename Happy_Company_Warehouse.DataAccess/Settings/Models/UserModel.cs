using System.ComponentModel.DataAnnotations;

namespace Happy_Company_Warehouse.DataAccess.Settings.Models
{
    public class UserModel
    {
   
        [Required, StringLength(50)]
        public string FullName { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; } 
    
        [Required]
        public string Role { get; set; }
        [Required]

        public bool Active { get; set; } = true;

 
    }
}