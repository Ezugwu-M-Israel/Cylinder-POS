using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using GasPOS.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace GasPOS.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserHelper(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ApplicationUser FindByEmail(string? email)
        {
            return _userManager.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public async Task<ApplicationUser>UserRegistertion(ApplicationUserViewModel applicationUserViewModel, string base64)
        {
            if (applicationUserViewModel != null)
            {
                var newAppUser = new ApplicationUser();
                {
                    newAppUser.FirstName = applicationUserViewModel.FirstName;
                    newAppUser.MiddleName = applicationUserViewModel.MiddleName;
                    newAppUser.LastName = applicationUserViewModel.LastName;
                    newAppUser.Email = applicationUserViewModel.Email;
                    newAppUser.UserName = applicationUserViewModel.Email;
                    newAppUser.Address = applicationUserViewModel.Address;
                    newAppUser.DateRegistered = DateTime.Now;
                    newAppUser.ProfilePicture = base64;               
                }
                var newresult = await _userManager.CreateAsync(newAppUser, applicationUserViewModel.Password);
                if (newresult.Succeeded)
                {
                    return newAppUser;

                }
            }
            return null;
        }










    }
}
