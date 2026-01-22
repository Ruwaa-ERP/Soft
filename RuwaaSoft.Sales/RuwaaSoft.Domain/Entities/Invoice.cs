using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Invoices")]
    public class Invoice : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        public InvoiceType InvoiceType { get; set; }

        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxPercentage { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal RemainingAmount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public bool IsPaid { get; set; } = false;

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
