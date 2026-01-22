using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string NameAr { get; set; }

        [MaxLength(50)]
        public string SKU { get; set; }

        [MaxLength(50)]
        public string Barcode { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? WholesalePrice { get; set; }

        public int MinStockLevel { get; set; } = 0;

        public int MaxStockLevel { get; set; } = 0;

        public bool HasDimensions { get; set; } = false;

        public bool HasVariants { get; set; } = false;

        public bool IsActive { get; set; } = true;

        [MaxLength(500)]
        public string ImagePath { get; set; }
    }
}
