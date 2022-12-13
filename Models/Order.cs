using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace GasPOS.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string?  CustomerName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public double QuantityBought { get; set; }
        public double AmountPaid { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
