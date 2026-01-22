using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Settings")]
    public class Setting : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Key { get; set; }

        [MaxLength(1000)]
        public string Value { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }
    }
}
