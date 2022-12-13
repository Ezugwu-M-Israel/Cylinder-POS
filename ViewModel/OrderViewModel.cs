using GasPOS.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasPOS.ViewModel
{
    public class OrderViewModel
    {
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public double QuantityBought { get; set; }
        public double AmountPaid { get; set; }

    }
}
