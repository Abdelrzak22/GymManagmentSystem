using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.AnalyticViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;

namespace GymManagmentBLL.Services.Classes
{
    public class AnalyticService : IAnalyticService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

        public AnalyticViewModel GetAnalyticData()
        {

            var session = _unitOfWork.sessionRepository.GetAll();

            return new AnalyticViewModel
            {
                TotalMembers = _unitOfWork.GetRepository<Member>().GetAll().Count(),
                TotalTrainers = _unitOfWork.GetRepository<Trainer>().GetAll().Count(),
                ActiveMember = _unitOfWork.GetRepository<MembePlan>().GetAll(x => x.Status == "Active").Count(),
                UpcomingSession = session.Count(x => x.CreatedAt > DateTime.Now),
                OngoingSession = session.Count(x => x.CreatedAt <= DateTime.Now && x.EndDate >= DateTime.Now),
                CompeletedSession = session.Count(x => x.EndDate < DateTime.Now)

            };
            
        }
    }
}
