using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using GasPOS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;

namespace GasPOS.Helpers
{
    public class AdminHelpers: IAdminHelpers
    {

        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAdminHelpers _adminHelpers;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminHelpers(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment, IAdminHelpers adminHelpers)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _adminHelpers = adminHelpers;   
        }
        public bool AddCynlinderCategory(CynlinderCategoryViewModel cynlinderCategoryViewModel)
        {
            if (cynlinderCategoryViewModel != null)
            {
                var cynlinder = new CynlinderCategory()
                {
                    Name = cynlinderCategoryViewModel.Name,
                    Quantity = cynlinderCategoryViewModel.Quantity,
                    Active =true,
                    Deleted = false,
                    DateCreated = DateTime.Now,
                };
                _context.CynlinderCategories.Add(cynlinder);
                _context.SaveChanges();
                return true;
            }
            return false;
        }     
        public List<CynlinderCategoryViewModel> GetListOfCynlinderCategories()
        {
            var listOfCynlinderCategories = new List<CynlinderCategoryViewModel>();
            var list = _context.CynlinderCategories.Where(x => x.Id != 0).ToList();
            if (list.Count > 0)
            {
                foreach (var lists in list)
                {
                    var cynlinderCategoryViewModel = new CynlinderCategoryViewModel()
                    {
                        Name = lists.Name,
                        Active = true,
                        Quantity = lists.Quantity,
                        Deleted = lists.Deleted,
                        DateCreated= DateTime.Now,
                        Id = lists.Id,
                    };
                    listOfCynlinderCategories.Add(cynlinderCategoryViewModel);
                }
                return listOfCynlinderCategories;
            }
            return listOfCynlinderCategories;
        }
        public CynlinderCategory GetCynliderByCynliderId(int id)
        {
            var cynlinderCategory = new CynlinderCategory();
            if (id != 0)
            {
                var category = _context.CynlinderCategories.Where(x => x.Id == id && x.Name != null).FirstOrDefault();
                if (category != null)
                {
                    return category;

                }
                return cynlinderCategory;
            }
            return cynlinderCategory;
        }

        public bool AddCynlinder(CynlinderViewModel cynlinderViewModel)
        {
            if (cynlinderViewModel != null)
            {
                var cynlinders = new Cynlinder()
                {
                    Name = cynlinderViewModel.Name,
                    Price = cynlinderViewModel.Price,
                    Active = true,
                    DateCreated = DateTime.Now,
                    Deleted = false,
                };
                _context.Cynlinders.Add(cynlinders);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CynlinderViewModel> ListOfCynlinder()
        {
            var listOfCynlinder = new List<CynlinderViewModel>();
            var list = _context.Cynlinders.Where(x => x.Id != 0).ToList();
            if (list.Count > 0)
            {
                foreach (var lists in list)
                {
                    var cynlinderViewModel = new CynlinderViewModel()
                    {
                        Name = lists.Name,
                        Active = true,
                        Deleted = lists.Deleted,
                        DateCreated = DateTime.Now,
                        Id = lists.Id,
                        Price = lists.Price,
                    };
                    listOfCynlinder.Add(cynlinderViewModel);
                }
                return listOfCynlinder;
            }
            return listOfCynlinder;
        }

        public Cynlinder GetCynlinderByCynlinderId(int id)
        {
            var cynlinder = new Cynlinder();
            if (id != 0)
            {
                var category = _context.Cynlinders.Where(x => x.Id == id && x.Name != null).FirstOrDefault();
                if (category != null)
                {
                    return category;

                }
                return cynlinder;
            }
            return cynlinder;
        }



    }
}
