using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GasPOS.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminHelpers _adminHelpers;
        public HomeController(AppDbContext context, ILogger<HomeController> logger, IAdminHelpers adminHelpers)
        {
            _logger = logger;
            _context = context;
            _adminHelpers = adminHelpers;
            
        }



        public IActionResult Index()
        {
            var topCynlinder = _adminHelpers.ListOfCynlinder().OrderByDescending(x => x.DateCreated).Take(8).ToList();
            return View(topCynlinder);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}