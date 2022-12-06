using System.ComponentModel.DataAnnotations.Schema;

namespace GasPOS.ViewModel
{
    public class ApplicationUserViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        public DateTime DateRegistered { get; set; }
        public bool IsDeactivated { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
