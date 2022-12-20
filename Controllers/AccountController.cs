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
                    if (applicationUserViewModel.FirstName == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your FirstName" });
                    }
                    if (applicationUserViewModel.MiddleName == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your MiddleName" });
                    }
                    if (applicationUserViewModel.LastName == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your LastName" });  // If posting with ASP.NET Forms chek null with the NULL keyword
                    }
                    if (applicationUserViewModel.Address == String.Empty) // If posting with jquery chek null with STRING.EMPTY
                    {
                        return Json(new { isError = true, msg = "Please Enter Your Address" });
                    }
                    if (applicationUserViewModel.Password != applicationUserViewModel.ConfirmPassword)
                    {
                        return Json(new { isError = true, msg = "Password and Confirm Password must match" });
                    }
                    if (applicationUserViewModel.Password?.Length < 5)
                    {
                        return Json(new { isError = true, msg = "Password cannot be less than 5" });
                    }
                    var createUser = await _userHelper.UserRegistertion(applicationUserViewModel, base64).ConfigureAwait(false);
                    if (createUser != null)
                    {
                        await _userManager.AddToRoleAsync(createUser, "User");
                        return Json(new { isError = false, msg = "Register Successfully" });
                    }
                }
            }
            return Json(new { isError = true, msg = "Error Ocurred" });
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
                if (applicationUserViewModel != null)
                {
                    if (applicationUserViewModel.Email == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your Emil" });
                    }
                    if (applicationUserViewModel.Password == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your Password" });
                    }
                    var existing = _userManager.Users.Where(u => u.UserName == applicationUserViewModel.Email).FirstOrDefault();
                    if (existing != null)
                    {
                        var PasswordSigin = await _signInManager.PasswordSignInAsync(applicationUserViewModel.Email, applicationUserViewModel.Password, true, false).ConfigureAwait(false);
                        if (PasswordSigin.Succeeded)
                        {
                            var userRole = _userHelper.GetUserDashboardPage(existing);
                            if (userRole != null)
                            {
                                return Json(new { isError = false, msg = "Login Successfully", url = userRole });

                            }
                            else
                            {
                                return Json(new { isError = false, msg = "Login Successfully" });

                            }
                        }

                    }
                    else
                    {
                        return Json(new { isError = true, msg = "Username does not Exist!" });

                    }
                }
              
            }
            return Json(new { isError = true, msg = "Login was Failed!" });
        }

        [HttpGet]
        public IActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AdminRegister(string adminDetails, string base64)
        {
            if (adminDetails != null)
            {
                var applicationUserViewModel = JsonConvert.DeserializeObject<ApplicationUserViewModel>(adminDetails);
                if (applicationUserViewModel != null)
                {
                    var user = _userHelper.FindByEmail(applicationUserViewModel.Email);
                    if (user != null)
                    {
                        return Json(new { isError = true, msg = "Please A user with this email already exist" });
                    }
                    if (applicationUserViewModel.FirstName == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your FirstName" });
                    }
                    if (applicationUserViewModel.MiddleName == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your MiddleName" });
                    }
                    if (applicationUserViewModel.LastName == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your LastName" });
                    }
                    if (applicationUserViewModel.Address == String.Empty)
                    {
                        return Json(new { isError = true, msg = "Please Enter Your Address" });
                    }
                    if (applicationUserViewModel.Password != applicationUserViewModel.ConfirmPassword)
                    {
                        return Json(new { isError = true, msg = "Password and Confirm Password must match" });
                    }
                    if (applicationUserViewModel.Password?.Length < 5)
                    {
                        return Json(new { isError = true, msg = "Password cannot be less than 5" });
                    }
                    var registerAdmin = await _userHelper.AdminRegistertion(applicationUserViewModel, base64).ConfigureAwait(false);
                    if (registerAdmin != null)
                    {
                        await _userManager.AddToRoleAsync(registerAdmin, "Admin");
                        return Json(new { isError = false, msg = "Register Successfully" });
                    }
                }
            }
            return Json(new { isError = true, msg = "Error Ocurred" });
        }
















    }
}
