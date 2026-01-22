using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("Suppliers")]
    public class Supplier : BaseEntity
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

        [MaxLength(20)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(20)]
        public string TaxNumber { get; set; }

        public int PaymentTermDays { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
