using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("DiscountPolicies")]
    public class DiscountPolicy : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
