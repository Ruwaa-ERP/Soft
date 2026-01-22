using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Returns")]
    public class Return : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string ReturnNumber { get; set; }

        public DateTime ReturnDate { get; set; } = DateTime.Now;

        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [MaxLength(500)]
        public string Reason { get; set; }

        public bool IsApproved { get; set; } = false;
    }
}
