namespace GasPOS.ViewModel
{
    public class CynlinderCategoryViewModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Quantity { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
