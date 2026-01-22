using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Domain.Entities
{
    [Table("StockMovements")]
    public class StockMovement : BaseEntity
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }

        public StockMovementType MovementType { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        public DateTime MovementDate { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string ReferenceNumber { get; set; }

        public int? ReferenceId { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
