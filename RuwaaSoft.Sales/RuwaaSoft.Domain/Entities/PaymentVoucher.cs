using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("PaymentVouchers")]
    public class PaymentVoucher : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string VoucherNumber { get; set; }

        public DateTime VoucherDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string ReceivedBy { get; set; }
    }
}
