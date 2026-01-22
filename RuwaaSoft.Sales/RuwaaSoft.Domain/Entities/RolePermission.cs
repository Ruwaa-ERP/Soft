using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Domain.Entities
{
    [Table("RolePermissions")]
    public class RolePermission : BaseEntity
    {
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [Required]
        [MaxLength(100)]
        public string Module { get; set; }

        public PermissionType Permission { get; set; }

        public bool IsGranted { get; set; } = false;
    }
}
