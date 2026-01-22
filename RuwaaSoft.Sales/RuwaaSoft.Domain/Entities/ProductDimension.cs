using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuwaaSoft.Domain.Entities
{
    [Table("ProductDimensions")]
    public class ProductDimension : BaseEntity
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Length { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Width { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Height { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Weight { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Volume { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Area { get; set; }

        [MaxLength(50)]
        public string DimensionUnit { get; set; }

        [MaxLength(50)]
        public string WeightUnit { get; set; }
    }
}
