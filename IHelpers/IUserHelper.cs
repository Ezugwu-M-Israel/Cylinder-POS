using GasPOS.Models;
using GasPOS.ViewModel;

namespace GasPOS.IHelpers
{
    public interface IUserHelper
    {
        ApplicationUser FindByEmail(string? email);
        Task<ApplicationUser> FindUserByIdAsync(string id);
        Task<ApplicationUser> FindUserByEmail(string email);
        string GetUserById(string username);
        ApplicationUser FindByUsername(string username);
        Task<ApplicationUser> FindByUserEmailAsync(string username);
        Task<ApplicationUser> FindByUserNameAsync(string username);
        Task<ApplicationUser>UserRegistertion(ApplicationUserViewModel applicationUserViewModel, string base64);
    }
}
