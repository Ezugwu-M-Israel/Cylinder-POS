using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using GasPOS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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



        [HttpGet]
        public IActionResult GetCynlinderByCynlinderId(int cynlinderId)
        {
            var customer = _adminHelpers.GetCynlinderByCynlinderId(cynlinderId);
            if (customer != null)
            {
                return View(customer);
            }
            return View(customer);
        }


        [HttpPost]
        public JsonResult Ordes(string orders)
        {
            if (orders != null)
            {
                var orderViewModel = JsonConvert.DeserializeObject<OrderViewModel>(orders);
                if (orderViewModel != null)
                {
                    var order = _adminHelpers.Order(orderViewModel);
                    if (order)
                    {
                        return Json(new { isError = false, msg = "You Have Successfully Place An Order" });
                    }
                    return Json(new { isError = true, msg = "Unable to Place An Order" });
                }
            }

            return Json(new { isError = true, msg = "Error Ocurred" });
        }



    }
}
