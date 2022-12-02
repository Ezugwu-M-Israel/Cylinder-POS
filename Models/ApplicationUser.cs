using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GasPOS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        public DateTime DateRegistered { get; set; }

        public bool IsDeactivated { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
