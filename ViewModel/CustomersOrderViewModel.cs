using GasPOS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GasPOS.ViewModel
{
    public class CustomersOrderViewModel
    {

        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        public DateTime DateRegistered { get; set; }
        public int? CynlinderId { get; set; }
        [ForeignKey("CynlinderId")]
        public virtual Cynlinder? Cynlinder { get; set; }
        public bool IsDeactivated { get; set; }
    }
}
