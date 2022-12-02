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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminHelpers(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;

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
     
        
        public List<CynlinderCategoryViewModel> ListOfCynlinderCategories()
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




        



    }
}
