using GymManagmentBLL.ViewModels.PlanViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Interfaces
{
    internal interface IPlanService
    {
        IEnumerable<PlanViewModel> GetAll();

        PlanViewModel? GetById(int PlanId);

        PlanToUpdate? GetPlanToUpdate(int PlanId);

        bool IsPlanUpdate(int PlanId, PlanToUpdate plan);

        bool ToggleStatus (int PlanId);  // delete function if active make it disactive 

    }
}
