using AutoMapper;
using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.SessionViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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



        private bool IsAllowedToUpdate(Session session)
        {
            if (session is null) return false;
            //if session completed
            if (session.EndDate >DateTime.Now) return false;
            //if session started

            if (session.CreatedAt <= DateTime.Now) return false;
            //if session has active booking
            var HasActiveSession = _unitOfWork.sessionRepository.BookingSession(session.Id) > 0;
            if (!HasActiveSession) return false;
            return true;

            
        }

        public UpdateSessionViewModel GetDataToUpdate(int id)
        {
            var session = _unitOfWork.sessionRepository.GetById(id);
            if (!IsAllowedToUpdate(session)) return null;

            return _mapper.Map<UpdateSessionViewModel>(session);    
        }


        public bool UpdateSession(int id, UpdateSessionViewModel updated)
        {
            try
            {
                var session = _unitOfWork.sessionRepository.GetById(id);
                if (!(IsAllowedToUpdate(session))) return false;
                if (!TrainerExist(updated.TrainerId)) return false;
                if (!DateValid(updated.StartDate, updated.EndDate)) return false;
                _mapper.Map<Session>(updated);
                session.UpdateAt = DateTime.Now;
                _unitOfWork.sessionRepository.update(session);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch(Exception ex)
            {

                Console.WriteLine($"dont updated sesion :{ex}");
                return false;
            }
        }

        public bool RemoveSession(int id)
        {
            try
            {
                var sesion = _unitOfWork.sessionRepository.GetById(id);
                if (!IsAllowedToRemove(sesion)) return false;
                _unitOfWork.sessionRepository.Delete(sesion);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
           
            
        }


        private bool IsAllowedToRemove(Session session)
        {
            if (session is null) return false;
            //if session upcoming
            if (session.CreatedAt > DateTime.Now) return false;
            //if session started

            if (session.CreatedAt <= DateTime.Now && session.EndDate>DateTime.Now) return false;
            //if session has active booking
            var HasActiveSession = _unitOfWork.sessionRepository.BookingSession(session.Id) > 0;
            if (!HasActiveSession) return false;
            return true;


        }
    }
}
