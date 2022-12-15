using GasPOS.Models;
using GasPOS.ViewModel;

namespace GasPOS.IHelpers
{
    public interface IAdminHelpers
    {
        bool AddCynlinderCategory(CynlinderCategoryViewModel cynlinderCategoryViewModel);
        List<CynlinderCategoryViewModel> GetListOfCynlinderCategories();
        CynlinderCategory GetCynliderCategoryByCynliderId(int id);
        bool AddCynlinder(CynlinderViewModel cynlinderViewModel, string base64);
        CynlinderViewModel GetCynlinderByCynlinderId(int id);
        List<CynlinderViewModel> ListOfCynlinder();
        Task<List<CynlinderCategory>> GetCynlinderCategory();
        bool Order(OrderViewModel orderViewModel);
        List<OrderViewModel> ListOfOrder();
        string UpdateCynlinderCategoryInfo(CynlinderCategoryViewModel cynlinderCategoryViewModel);
        string UpdateCynlinderInfo(CynlinderViewModel cynlinderViewModel);
    }
}
