using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Units")]
    public class Unit : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string NameAr { get; set; }

        [MaxLength(10)]
        public string Symbol { get; set; }

        public UnitType UnitType { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
