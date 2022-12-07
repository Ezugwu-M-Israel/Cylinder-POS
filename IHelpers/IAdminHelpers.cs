using GasPOS.Models;
using GasPOS.ViewModel;

namespace GasPOS.IHelpers
{
    public interface IAdminHelpers
    {
        bool AddCynlinderCategory(CynlinderCategoryViewModel cynlinderCategoryViewModel);
        List<CynlinderCategoryViewModel> GetListOfCynlinderCategories();
        CynlinderCategory GetCynliderByCynliderId(int id);
        bool AddCynlinder(CynlinderViewModel cynlinderViewModel, string base64);
        Cynlinder GetCynlinderByCynlinderId(int id);
        List<CynlinderViewModel> ListOfCynlinder();
        Task<List<CynlinderCategory>> GetCynlinderCategory();
    }
}
