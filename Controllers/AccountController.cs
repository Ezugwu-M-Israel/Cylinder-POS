using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using GasPOS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GasPOS.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserHelper _userHelper;

        public AccountController(AppDbContext context, IUserHelper userHelper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Register(string userDetails, string base64)
        {
            if (userDetails != null)
            {
                var applicationUserViewModel = JsonConvert.DeserializeObject<ApplicationUserViewModel>(userDetails);
                if (applicationUserViewModel != null)
                {
                    var user = _userHelper.FindByEmail(applicationUserViewModel.Email);
                    if (user != null)
                    {
                        return Json(new { isError = false, msg = "Please A user with this email already exist" });
                    }
                    if (applicationUserViewModel.FirstName == null)
                    {
                        return Json(new { isError = false, msg = "Please Enter Your FirstName" });
                    }
                    if (applicationUserViewModel.MiddleName == null)
                    {
                        return Json(new { isError = false, msg = "Please Enter Your MiddleName" });
                    }
                    if (applicationUserViewModel.LastName == null)
                    {
                        return Json(new { isError = false, msg = "Please Enter Your LastName" });
                    }
                    if (applicationUserViewModel.Address == null)
                    {
                        return Json(new { isError = false, msg = "Please Enter Your Address" });
                    }
                    if (applicationUserViewModel.Password != applicationUserViewModel.ConfirmPassword)
                    {
                        return Json(new { isError = false, msg = "Password and Confirm Password must match" });
                    }
                    var registerUser = await _userHelper.UserRegistertion(applicationUserViewModel, base64).ConfigureAwait(false);
                    if (registerUser != null)
                    {
                        await _userManager.AddToRoleAsync(registerUser, "Admin");
                        return Json(new { isError = true, msg = "Register Successfully" });
                    }
                }

            }
            return Json(new { isError = false, msg = "Error Ocurred" });
        }
















        
    }
}
