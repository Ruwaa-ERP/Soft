using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("PrintTemplates")]
    public class PrintTemplate : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string TemplateType { get; set; }

        [MaxLength(4000)]
        public string TemplateContent { get; set; }

        public bool IsDefault { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}
