using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Receipts")]
    public class Receipt : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string ReceiptNumber { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public int? InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
