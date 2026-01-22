using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [MaxLength(255)]
        public string Salt { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public int? BranchId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public UserStatus Status { get; set; } = UserStatus.Active;

        public DateTime? LastLoginAt { get; set; }

        [MaxLength(50)]
        public string LastLoginIP { get; set; }
    }
}
