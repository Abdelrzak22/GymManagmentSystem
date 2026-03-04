using GymManagmentBLL.ViewModels.SessionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Interfaces
{
    internal interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSessionViewModels();

        SessionViewModel? GetSessionById(int id);

        bool Create(CreateSessionViewModel CreatedSession);

        UpdateSessionViewModel GetDataToUpdate(int id);
        bool UpdateSession(int id, UpdateSessionViewModel updated);
    }
}
