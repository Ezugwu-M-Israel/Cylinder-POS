using GasPOS.Models;
using GasPOS.ViewModel;

namespace GasPOS.IHelpers
{
    public interface IUserHelper
    {
        ApplicationUser FindByEmail(string? email);
        Task<ApplicationUser>UserRegistertion(ApplicationUserViewModel applicationUserViewModel, string base64);
    }
}
