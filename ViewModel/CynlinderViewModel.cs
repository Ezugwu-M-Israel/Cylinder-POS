using GasPOS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GasPOS.ViewModel
{
    public class CynlinderViewModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public string CynlinderCategoryName { get; set; }
        public int CynlinderCategoryId { get; set; }
        public bool Active { get; set; }
        public string TotalAmount { get; set; }
        public double Quantity { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
