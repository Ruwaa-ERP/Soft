using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("ExpenseVouchers")]
    public class ExpenseVoucher : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string VoucherNumber { get; set; }

        public DateTime VoucherDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string PaidTo { get; set; }
    }
}
