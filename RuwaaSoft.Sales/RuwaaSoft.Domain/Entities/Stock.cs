using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Stock")]
    public class Stock : BaseEntity
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int? ProductVariantId { get; set; }

        [ForeignKey("ProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal ReservedQuantity { get; set; } = 0;

        [Column(TypeName = "decimal(18,3)")]
        public decimal AvailableQuantity { get; set; }
    }
}
