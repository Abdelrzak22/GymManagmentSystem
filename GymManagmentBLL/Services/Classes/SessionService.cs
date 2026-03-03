using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.SessionViewModel;
using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Classes
{
    internal class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IEnumerable<SessionViewModel> GetAllSessionViewModels()
        {
            var Data = _unitOfWork.sessionRepository.GetAllSessionWithTrainerAndCategoty();

            if (Data is null) return [];

            return Data.Select(x => new SessionViewModel
            {
                Id = x.Id,
                Capacity = x.Capacity,
                StartDate = x.CreatedAt,
                EndDate = x.EndDate,
                Description = x.Description,
                CategoryName = x.Category.CategoryName,
                TrainerName = x.trainer.Name,
                AvailableSlots = x.Capacity - _unitOfWork.sessionRepository.BookingSession(x.Id)

            });
        }
    }
}
