using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuwaaSoft.Domain.Enums;

namespace RuwaaSoft.Domain.Entities
{
    [Table("AuditLogs")]
    public class AuditLog : BaseEntity
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public AuditAction Action { get; set; }

        [Required]
        [MaxLength(100)]
        public string TableName { get; set; }

        public int? RecordId { get; set; }

        [MaxLength(2000)]
        public string OldValues { get; set; }

        [MaxLength(2000)]
        public string NewValues { get; set; }

        public DateTime ActionDate { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string IPAddress { get; set; }
    }
}
