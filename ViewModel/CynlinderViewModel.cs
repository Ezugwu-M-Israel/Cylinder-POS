using GasPOS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GasPOS.ViewModel
{
    public class CynlinderViewModel
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
        public DateTime DateCreated { get; set; }
    }
}
