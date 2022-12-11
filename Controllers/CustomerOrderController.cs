using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GasPOS.Controllers
{
    public class CustomerOrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAdminHelpers _adminHelpers;

        public CustomerOrderController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAdminHelpers adminHelpers)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _adminHelpers = adminHelpers;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var customer = _adminHelpers.ListOfCynlinder();
            if (customer != null && customer.Count > 0)
            {
                return View(customer);
            }
            return View(customer);
        }







    }
}
