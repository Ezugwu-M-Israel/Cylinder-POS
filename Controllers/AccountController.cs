using Microsoft.AspNetCore.Mvc;

namespace GasPOS.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
