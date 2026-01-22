using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Installments")]
    public class Installment : BaseEntity
    {
        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        public int InstallmentNumber { get; set; }

        public DateTime DueDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; } = 0;

        public bool IsPaid { get; set; } = false;

        public DateTime? PaidDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
