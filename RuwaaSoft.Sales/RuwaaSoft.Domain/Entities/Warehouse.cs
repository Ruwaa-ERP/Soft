using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Warehouses")]
    public class Warehouse : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string NameAr { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public int? BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
