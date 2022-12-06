using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using GasPOS.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ApplicationUser> FindByUserNameAsync(string username)
        {
            return await _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser> FindByUserEmailAsync(string username)
        {
            return await _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
        public ApplicationUser FindByUsername(string username)
        {
            return _userManager.Users.Where(x => x.UserName == username).FirstOrDefault();
        }
        public string GetUserById(string username)
        {
            return _userManager.Users.Where(x => x.UserName == username).FirstOrDefaultAsync().Result.Id?.ToString();
        }
        public async Task<ApplicationUser> FindUserByEmail(string email)
        {
            return await _userManager.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
        public async Task<ApplicationUser> FindUserByIdAsync(string id)
        {
            return await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
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
