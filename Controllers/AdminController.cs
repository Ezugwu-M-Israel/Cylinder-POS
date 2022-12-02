using Microsoft.AspNetCore.Mvc;

namespace GasPOS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
