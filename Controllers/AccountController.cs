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
                        return Json(new { isError = true, msg = "Please A user with this email already exist" });
                    }
                    if (applicationUserViewModel.FirstName == null)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your FirstName" });
                    }
                    if (applicationUserViewModel.MiddleName == null)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your MiddleName" });
                    }
                    if (applicationUserViewModel.LastName == null)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your LastName" });
                    }
                    if (applicationUserViewModel.Address == null)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your Address" });
                    }
                    if (applicationUserViewModel.Password != applicationUserViewModel.ConfirmPassword)
                    {
                        return Json(new { isError = true, msg = "Password and Confirm Password must match" });
                    }
                    var registerUser = await _userHelper.UserRegistertion(applicationUserViewModel, base64).ConfigureAwait(false);
                    if (registerUser != null)
                    {
                        await _userManager.AddToRoleAsync(registerUser, "Admin");
                        return Json(new { isError = false, msg = "Register Successfully" });
                    }
                }
            }
            return Json(new { isError = false, msg = "Error Ocurred" });
        }


        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string loginDetails)
        {
            if (loginDetails != null)
            {
                var applicationUserViewModel = JsonConvert.DeserializeObject<ApplicationUserViewModel>(loginDetails);
                if (applicationUserViewModel.Email == null)
                {
                    return Json(new { isError = true, msg = "Please Enter Your Emil" });
                }
                if (applicationUserViewModel.Password == null)
                {
                    return Json(new { isError = true, msg = "Please Enter Your Password" });
                }
                var existing = _userManager.Users.Where(u => u.UserName == applicationUserViewModel.Email).FirstOrDefault();
                if (existing != null)
                {
                    var PasswordSigin =await _signInManager.PasswordSignInAsync(applicationUserViewModel.Email, applicationUserViewModel.Password, true, false).ConfigureAwait(false);
                    if (PasswordSigin.Succeeded)
                    {
                        var userRole = _userManager.IsInRoleAsync(existing, "Admin").Result;
                        if (userRole)
                        {
                            return Json(new { isError = false, msg = "Login Successfully" });

                            //TempData["success"] = "Successfully!";
                            //return RedirectToAction("AdminDashboard", "Admin");
                        }
                        else
                        {
                            return Json(new { isError = false, msg = "Login Successfully" });
                            //TempData["success"] = "Successfully!";
                            //, redirectUrl = "/Home/Index"
                            //return RedirectToAction("Index", "Home");
                        }
                    }

                }
                else
                {
                    return Json(new { isError = false, msg = "Username does not Exist!" });
                    
                }
            }
            return Json(new { isError = false, msg = "Login was Failed!" });
        }













    }
}
