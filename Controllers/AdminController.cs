﻿using GasPOS.Db;
using GasPOS.Helpers;
using GasPOS.IHelpers;
using GasPOS.Models;
using GasPOS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Buffers.Text;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace GasPOS.Controllers
{
    public class AdminController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAdminHelpers _adminHelpers;   
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment, IAdminHelpers adminHelpers)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _adminHelpers = adminHelpers;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CynlinderCategory()
        {
            var cynlinder = _adminHelpers.GetListOfCynlinderCategories();
            if (cynlinder != null && cynlinder.Count > 0)
            {
                return View(cynlinder);
            }
            return View(cynlinder);
        }

        [HttpPost]
        public JsonResult AddCynlinderCategory(string category)
        {
            if (category != null)
            {
                var cynlinderCategoryViewModel = JsonConvert.DeserializeObject<CynlinderCategoryViewModel>(category);
                if (cynlinderCategoryViewModel != null)
                {
                    var addCynlinderCategory = _adminHelpers.AddCynlinderCategory(cynlinderCategoryViewModel);
                    if (addCynlinderCategory)
                    {
                        return Json(new { isError = false, msg = "CynlinderCategory created Successfully" });
                    }
                    return Json(new { isError = true, msg = "Unable to create CynlinderCategory" });
                }
            }
            return Json(new { isError = true, msg = "Error Ocurred" });
        }





    }
}
