using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasPOS.Models
{
    public class Cynlinder
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? CynlinderCategoryId { get; set; }
        [ForeignKey("CynlinderCategoryId")]
        public virtual CynlinderCategory? CynlinderCategory { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public bool DateCreated { get; set; }
    }
}
