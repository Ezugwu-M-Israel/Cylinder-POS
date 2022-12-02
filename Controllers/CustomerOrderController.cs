using Microsoft.AspNetCore.Mvc;

namespace GasPOS.Controllers
{
    public class CustomerOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
