using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("InvoiceDetails")]
    public class InvoiceDetail : BaseEntity
    {
        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int? ProductVariantId { get; set; }

        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxAmount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}
