using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("ProductVariants")]
    public class ProductVariant : BaseEntity
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required]
        [MaxLength(100)]
        public string VariantName { get; set; }

        [MaxLength(50)]
        public string SKU { get; set; }

        [MaxLength(50)]
        public string Barcode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AdditionalPrice { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        [MaxLength(50)]
        public string Size { get; set; }

        [MaxLength(50)]
        public string Material { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
