using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using GasPOS.ViewModel;
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

		public async Task<ApplicationUser> UserRegistertion(ApplicationUserViewModel applicationUserViewModel, string base64)
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

		public async Task<ApplicationUser> AdminRegistertion(ApplicationUserViewModel model, string base64)
		{
			try
			{
				if (model != null)
				{
					var newModel = new ApplicationUser();
					{
						newModel.FirstName = model.FirstName;
						newModel.MiddleName = model.MiddleName;
						newModel.LastName = model.LastName;
						newModel.Address = model.Address;
						newModel.UserName = model.Email;
						newModel.Email = model.Email;
						newModel.DateRegistered = DateTime.Now;
						newModel.ProfilePicture = base64;
					}
					var abuchi = await _userManager.CreateAsync(newModel, model.Password);
					if (abuchi.Succeeded)
					{
						return newModel;
					}
				}
				return null;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public string GetUserDashboardPage(ApplicationUser userr)
		{
			var userRole = _userManager.GetRolesAsync(userr).Result.FirstOrDefault();
			if (userRole != null)
			{
				if (userRole == "Admin")
				{
					return "/Admin/Index";
				}
				else
				{
					return "/Home/Index";
				}
			}
			return null;
		}

		public async Task<bool> CheckIfUserIsAdmin(string username)
		{
			try
			{
				if (username == null)
				{
					return false;
				}
				var currentUser = FindByUserNameAsync(username);
				var userDetails = await _userManager.Users.Where(s => s.UserName == currentUser.Result.UserName)?.FirstOrDefaultAsync();
				if (userDetails != null)
				{
					var goAdmin = await _userManager.IsInRoleAsync(userDetails, "Admin");
					if (goAdmin)
					{
						return goAdmin;
					}
					else
					{
						return false;
					}

				}
				return false;

			}

			catch (Exception)
			{
				throw;
			}

		}
		public string GetRoleLayout(string username)
		{
			if (username == null)
			{
				return null;
			}
			var applicationUser = _userManager.Users.Where(u => u.UserName == username).FirstOrDefault();
			var superAdmin = _userManager.IsInRoleAsync(applicationUser, "Admin").Result;
			if (superAdmin)
			{
				return "~/Views/Shared/_AdminLayout.cshtml";
			}
			else if (!superAdmin)
			{
				var companyAdmin = _userManager.IsInRoleAsync(applicationUser, "Employee").Result;
				if (companyAdmin)
				{
					return "~/Views/Shared/_UserLayout.cshtml";
				}
				else
				{
					var user = _userManager.IsInRoleAsync(applicationUser, "User").Result;
					return "~/Views/Shared/_Layout.cshtml";
				}
			}
			return null;
		}





	}
}
