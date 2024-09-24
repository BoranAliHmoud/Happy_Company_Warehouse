using System.ComponentModel.DataAnnotations;

namespace Happy_Company_Warehouse.DataAccess.Settings.Models
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string tenantId { get; set; }
    }
}