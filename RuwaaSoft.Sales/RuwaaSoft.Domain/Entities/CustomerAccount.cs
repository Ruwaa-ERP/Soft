using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("CustomerAccounts")]
    public class CustomerAccount : BaseEntity
    {
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string ReferenceNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Debit { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
