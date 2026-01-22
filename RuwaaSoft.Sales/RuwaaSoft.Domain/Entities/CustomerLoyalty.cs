using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("CustomerLoyalty")]
    public class CustomerLoyalty : BaseEntity
    {
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int Points { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSpent { get; set; } = 0;

        public int TotalOrders { get; set; } = 0;
    }
}
