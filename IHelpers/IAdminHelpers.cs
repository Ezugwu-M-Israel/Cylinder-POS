using GasPOS.Models;
using GasPOS.ViewModel;

namespace GasPOS.IHelpers
{
    public interface IAdminHelpers
    {
        bool AddCynlinderCategory(CynlinderCategoryViewModel cynlinderCategoryViewModel);
        List<CynlinderCategoryViewModel> ListOfCynlinderCategories();
        CynlinderCategory GetCynliderByCynliderId(int id);
        bool AddCynlinder(CynlinderViewModel cynlinderViewModel);
        Cynlinder GetCynlinderByCynlinderId(int id);
        List<CynlinderViewModel> ListOfCynlinder();
    }
}
