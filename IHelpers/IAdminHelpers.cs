using GasPOS.Models;
using GasPOS.ViewModel;

namespace GasPOS.IHelpers
{
    public interface IAdminHelpers
    {
        bool AddCynlinderCategory(CynlinderCategoryViewModel cynlinderCategoryViewModel);
        List<CynlinderCategoryViewModel> ListOfCynlinderCategories();
        CynlinderCategoryViewModel GetCynliderByCynliderId(int id);
    }
}
