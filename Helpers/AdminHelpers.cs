using GasPOS.Db;
using GasPOS.IHelpers;
using GasPOS.Models;
using GasPOS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Buffers.Text;

namespace GasPOS.Helpers
{
    public class AdminHelpers: IAdminHelpers
    {

        private readonly AppDbContext _context;

        public AdminHelpers(AppDbContext context)
        {
            _context = context; 
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
        public CynlinderCategory GetCynliderCategoryByCynliderId(int id)
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

        public bool AddCynlinder(CynlinderViewModel cynlinderViewModel, string base64)
        {
            try
            {
                if (cynlinderViewModel != null)
                {
                    var cynlinders = new Cynlinder()
                    {
                        Name = cynlinderViewModel.Name,
                        Price = cynlinderViewModel.Price,
                        CynlinderCategoryId = cynlinderViewModel.CynlinderCategoryId,
                        Active = true,
                        DateCreated = DateTime.Now,
                        Deleted = false,
                        ImageUrl = base64,
                    };
                    _context.Add(cynlinders);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
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
                        ImageUrl = lists.ImageUrl,
                        Id = lists.Id,
                        Price = lists.Price,
                    };
                    listOfCynlinder.Add(cynlinderViewModel);
                }
                return listOfCynlinder;
            }
            return listOfCynlinder;
        }

        public CynlinderViewModel GetCynlinderByCynlinderId(int id)
        {
            
            if (id != 0)
            {
                var category = _context.Cynlinders.Where(x => x.Id == id && x.Name != null).Include(x => x.CynlinderCategory).FirstOrDefault();
                if (category != null)
                {
                    var cynlinder = new CynlinderViewModel()
                    {
                        Id = category.Id,
                        Name = category.Name,   
                        Price = category.Price,
                        CynlinderCategoryName = category.CynlinderCategory?.Name,
                        DateCreated = category.DateCreated,
                        ImageUrl = category.ImageUrl,
                    };
                    return cynlinder;
                }
            }
            return null;
        }

        //public List<CynlinderCategoryViewModel> ListOfCynlinderCategory()
        //{
        //    var listOfCynlinderCategory = new List<CynlinderCategoryViewModel>();
        //    var categorys = _context.CynlinderCategories.Where(u => u.Id != 0 && !u.Deleted).ToList();
        //    if (categorys.Count() > 0)
        //    {
        //        foreach(var category in categorys)
        //        {
        //            var categoryViewModel = new CynlinderCategoryViewModel()
        //            {
        //                Id = category.Id,
        //                Name = category.Name,
        //            };
        //            listOfCynlinderCategory.Add(categoryViewModel);
        //        }
        //        return listOfCynlinderCategory;
        //    }
        //    return listOfCynlinderCategory;
        //}

        public async Task<List<CynlinderCategory>> GetCynlinderCategory()
        {
            try
            {
                var common = new CynlinderCategory()
                {
                    Id = 0,
                    Name = "___Select___"
                };
                var listOfCynlinderCategorys = await _context.CynlinderCategories.Where(a => a.Id != 0 && !a.Deleted).OrderBy(m => m.Name).ToListAsync();

                listOfCynlinderCategorys.Insert(0, common);
                return listOfCynlinderCategorys;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Order (OrderViewModel orderViewModel)
        {
            try
            {
                if (orderViewModel != null)
                {
                    var order = new Order()
                    {
                        CustomerName = orderViewModel.CustomerName,
                        CustomerPhoneNumber = orderViewModel.CustomerPhoneNumber,
                        ProductName = orderViewModel.ProductName,
                        AmountPaid = orderViewModel.AmountPaid,
                        QuantityBought =orderViewModel.QuantityBought,
                        DateCreated = DateTime.Now,
                        Active = true,
                        Deleted = false,
                    };
                    _context.Add(order);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }













        public List<OrderViewModel> ListOfOrder()
        {
            var listOfOrder = new List<OrderViewModel>();
            var list = _context.Orders.Where(o => o.Id != 0).ToList();
            if (list.Count > 0)
            {
                foreach (var lists in list)
                {
                    var order = new OrderViewModel()
                    {
                        CustomerName = lists.CustomerName,
                        AmountPaid = lists.AmountPaid,
                        CustomerPhoneNumber = lists.CustomerPhoneNumber,
                        ProductName = lists.ProductName,
                        QuantityBought = lists.QuantityBought,
                    };
                    listOfOrder.Add(order); 
                }
                return listOfOrder;
            }
            return listOfOrder;
        }





    }

}
