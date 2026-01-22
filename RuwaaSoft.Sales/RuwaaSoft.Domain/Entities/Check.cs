using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Checks")]
    public class Check : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string CheckNumber { get; set; }

        public DateTime CheckDate { get; set; }

        public DateTime DueDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public int? BankId { get; set; }

        [ForeignKey("BankId")]
        public virtual Bank Bank { get; set; }

        public CheckStatus Status { get; set; } = CheckStatus.Pending;

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
