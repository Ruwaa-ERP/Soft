using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string NameAr { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsSystemRole { get; set; } = false;
    }
}
