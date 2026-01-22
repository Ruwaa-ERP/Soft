using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Branches")]
    public class Branch : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string NameAr { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsMainBranch { get; set; } = false;
    }
}
