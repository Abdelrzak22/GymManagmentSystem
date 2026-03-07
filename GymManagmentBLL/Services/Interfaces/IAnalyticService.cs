using GymManagmentBLL.ViewModels.AnalyticViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Interfaces
{
    public interface IAnalyticService
    {
        AnalyticViewModel GetAnalyticData();
    }
}
