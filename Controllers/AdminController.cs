using GasPOS.Db;
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
            var cynlinder = _adminHelpers.GetListOfCynlinderCategories().Count;
            var list = _adminHelpers.ListOfOrder();
            var cynlinderInt = _adminHelpers.ListOfCynlinder().Count;
            var indexPage = new AdminViewModel()
            {
                NumberOfCynlinder = cynlinderInt,
                NumberOfCynlinderCategory = cynlinder,
                Orders = list,
            };
            return View(indexPage);
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

        [HttpGet]
        public IActionResult Cynlinder()
        {
            ViewBag.CynlinderCategory = _adminHelpers.GetCynlinderCategory().Result;
            var category = _adminHelpers.ListOfCynlinder();
            if (category != null)
            {
                return View(category);
            }
            return View(category);
        }

        [HttpPost]
        public async Task<JsonResult> AddCynlinder(string gasCynlinder, string base64)
        {
            ViewBag.CynlinderCategory = _adminHelpers.GetCynlinderCategory().Result;
            if (gasCynlinder != null)
            {
                var cynlinderViewModel = JsonConvert.DeserializeObject<CynlinderViewModel>(gasCynlinder);
                if (cynlinderViewModel != null)
                {
                    var addCynlinder = _adminHelpers.AddCynlinder(cynlinderViewModel, base64);
                    if (addCynlinder)
                    {
                        return Json(new { isError = false, msg = "Cynlinder created Successfully" });
                    }
                    return Json(new { isError = true, msg = "Unable to create Cynlinder" });
                }
            }
            return Json(new { isError = true, msg = "Error Ocurred" });
        }


        [HttpGet]
        public  IActionResult AdminTable()
        {
            var list = _adminHelpers.ListOfOrder();
            if (list != null)
            {
                return View(list);
            }
            return View(list);
        }


        [HttpGet]
        public JsonResult EditedCynlinderCategory(int cynlinderCategoryId)
        {
            try
            {
                if (cynlinderCategoryId > 0)
                {
                    var cynlin = _context.CynlinderCategories.Where(x => x.Id == cynlinderCategoryId && x.Active && !x.Deleted).FirstOrDefault();
                    if (cynlin != null)
                    {
                        return Json(new { isError = false, data = cynlin });
                    }
                    return Json(new { isError = true, msg = "Could not Edit CynlinderCategory." });
                }
                else
                {
                    return Json(new { isError = true, msg = "Could not Edit CynlinderCategory." });
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }


        [HttpPost]
        public JsonResult EditedCynlinderCategory(string cynlinderss)
        {
            try
            {
                if (cynlinderss != null)
                {
                    var editCynlinderCategory = JsonConvert.DeserializeObject<CynlinderCategoryViewModel>(cynlinderss);
                    if (editCynlinderCategory != null)
                    {
                        var updateCynlinderCategroyDetails = _adminHelpers.UpdateCynlinderCategoryInfo(editCynlinderCategory);
                        if (updateCynlinderCategroyDetails != null)
                        {
                            return Json(new { isError = false, msg = "CynlinderCategory Edited Successfully." });
                        }
                    }
                    return Json(new { isError = true, msg = "Something went wrong." });
                }
                return Json(new { isError = true, msg = "Something went wrong." });

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }



        [HttpGet]
        public IActionResult DeleteCynlinderCategory()
        {
            return View();
        }


        [HttpPost]
        public JsonResult DeleteCynlinderCategory(int categoryId)
        {
            try
            {

                if (categoryId != 0)
                {
                    var cynlinderCategoryToBeDeleted = _context.CynlinderCategories.Where(x => x.Id == categoryId && x.Deleted == false).FirstOrDefault();
                    if (cynlinderCategoryToBeDeleted != null)
                    {
                        cynlinderCategoryToBeDeleted.Deleted = true;
                        cynlinderCategoryToBeDeleted.Active = false;
                        _context.CynlinderCategories.Update(cynlinderCategoryToBeDeleted);
                        _context.SaveChanges();
                        return Json(new { isError = false, msg = "CynlinderCategory Deleted Successfully." });
                    }
                    return Json(new { isError = true, msg = "Could not Delete CynlinderCategory." });
                }
                return Json(new { isError = true, msg = "Failed please try again." });

            }
            catch (Exception)
            {

                throw;
            }
        }







    }
}
