using AutoMapper;
using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.SessionViewModel;
using GymManagmentDAL.Entities;
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
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork,IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Create(CreateSessionViewModel CreatedSession)
        {

            try
            {
                if (!TrainerExist(CreatedSession.TrainerId)) return false;
                if (!CategoryExists(CreatedSession.CategoryId)) return false;
                if (!DateValid(CreatedSession.StartDate, CreatedSession.EndDate)) return false;
                if (!(CreatedSession.Capacity > 25 || CreatedSession.Capacity < 0)) return false;

                var Session = _mapper.Map<Session>(CreatedSession);
                _unitOfWork.GetRepository<Session>().Add(Session);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"create session faild:{ex}");
                return false;
            }


        }

        public IEnumerable<SessionViewModel> GetAllSessionViewModels()
        {
            var Data = _unitOfWork.sessionRepository.GetAllSessionWithTrainerAndCategoty();

            if (Data is null) return [];

            //return Data.Select(x => new SessionViewModel
            //{
            //    Id = x.Id,
            //    Capacity = x.Capacity,
            //    StartDate = x.CreatedAt,
            //    EndDate = x.EndDate,
            //    Description = x.Description,
            //    CategoryName = x.Category.CategoryName,
            //    TrainerName = x.trainer.Name,
            //    AvailableSlots = x.Capacity - _unitOfWork.sessionRepository.BookingSession(x.Id)

            //});MAUAL MAPPING

            var mapped = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(Data);
            foreach(var session in mapped)
            {
                session.AvailableSlots = session.Capacity - _unitOfWork.sessionRepository.BookingSession(session.Id);


            }
            return mapped;


        }

        public SessionViewModel? GetSessionById(int id)
        {
            var Session = _unitOfWork.sessionRepository.GetSessionWithTrainerAndCategory(id);
            if (Session is null) return null;
            //return new SessionViewModel
            //{

            //    Capacity = Session.Capacity,
            //    StartDate = Session.CreatedAt,
            //    EndDate = Session.EndDate,
            //    Description = Session.Description,
            //    CategoryName = Session.Category.CategoryName,
            //    TrainerName = Session.trainer.Name,
            //    AvailableSlots = Session.Capacity - _unitOfWork.sessionRepository.BookingSession(Session.Id)


            //};

            var Mappedsession=_mapper.Map<Session,SessionViewModel>(Session);

            Mappedsession.AvailableSlots = Mappedsession.Capacity - _unitOfWork.sessionRepository.BookingSession(Mappedsession.Id);
                return Mappedsession;

        }


        private bool TrainerExist(int id)
        {
           return _unitOfWork.GetRepository<Trainer>().GetById(id) is not null;
        }

        private bool CategoryExists(int id)
        {
            return _unitOfWork.GetRepository<Category>().GetById(id) is not null;
        }

        private bool DateValid(DateTime Start, DateTime End)
        {
            return Start < End;
        }
    }
}
