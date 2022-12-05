using Microsoft.AspNetCore.Mvc;

namespace GasPOS.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
