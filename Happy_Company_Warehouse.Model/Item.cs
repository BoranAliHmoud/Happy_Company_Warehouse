using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Company_Warehouse.Model
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Item name cannot exceed 100 characters.")]
        public string ItemName { get; set; }

        [StringLength(50, ErrorMessage = "SKU Code cannot exceed 50 characters.")]
        public string SKUCode { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Qty { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost Price must be greater than 0.")]
        public decimal CostPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "MSRP Price must be greater than 0.")]
        public decimal? MSRPPrice { get; set; }

        [Required]
        public int WarehouseId { get; set; } // Foreign key

        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
    }
}
