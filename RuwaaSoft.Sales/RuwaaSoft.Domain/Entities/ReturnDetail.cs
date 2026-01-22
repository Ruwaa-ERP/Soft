using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("ReturnDetails")]
    public class ReturnDetail : BaseEntity
    {
        public int ReturnId { get; set; }

        [ForeignKey("ReturnId")]
        public virtual Return Return { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}
