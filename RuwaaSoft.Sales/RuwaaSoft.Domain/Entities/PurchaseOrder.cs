using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("PurchaseOrders")]
    public class PurchaseOrder : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        public bool IsReceived { get; set; } = false;

        public DateTime? ReceivedDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
