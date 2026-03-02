using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.TrainerViewModel;
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
    internal class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(IUnitOfWork unitOfWork) {
          _unitOfWork = unitOfWork;
        }
        public bool CreateTrainer(CreateTrainerVIewModel model)
        {

            if (EmailExist(model.Email) || (PhoneExist(model.Phone))) return false;

            var Trainer = new Trainer()
            {
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Gender = model.Gender,
                Dateofbirth = model.DateOfBirth,
                Address = new Address()
                {
                    City = model.City,
                    Street = model.Street,
                    BuldingNumber = model.BuildingNumber
                },
                specialties = model.Specialties

            };

            _unitOfWork.GetRepository<Trainer>().Add(Trainer);
            return _unitOfWork.SaveChanges() > 0;

        }
            
        

        public bool Delete(int TrainerId)
        {

            var Trainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (Trainer is null || ActiveSession(TrainerId)) return false;
            _unitOfWork.GetRepository<Trainer>().Delete(Trainer);
            return _unitOfWork.SaveChanges() > 0;

        }

        public TrainerViewModel? GetById(int TrainerId)
        {
            var Trainer= _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if(Trainer is null) return null;

            return new TrainerViewModel()
            {
                Name = Trainer.Name,
                Phone = Trainer.Phone,
                Email = Trainer.Email,
                DateOfBirth =Trainer.Dateofbirth.ToString(),
                Address = $"{Trainer.Address.BuldingNumber}-{Trainer.Address.Street}-{Trainer.Address.City}",
                Specialties=Trainer.specialties.ToString()


            };

        }

        public TrainerUpdateViewModel? GetDataToUpdate(int TrainerId)
        {
            var Trainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (Trainer is null) return null;

            return new TrainerUpdateViewModel()
            {
                Name = Trainer.Name,
                Email = Trainer.Email,
                Phone = Trainer.Phone,
                City = Trainer.Address.City,
                Street = Trainer.Address.Street,
                BuildingNumber = Trainer.Address.BuldingNumber,
                Specialties = Trainer.specialties
            };
        }

        public IEnumerable<TrainerViewModel> GetTrainers()
        {
           
            var trainers=_unitOfWork.GetRepository<Trainer>().GetAll();
            if (trainers is null) return [];

            var trainer = trainers.Select(x => new TrainerViewModel()
            {
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                DateOfBirth = x.Dateofbirth.ToString(),
                Specialties = x.specialties.ToString()

            });

            return trainer;
        }

        public bool Update(int TrainerId, TrainerUpdateViewModel trainerUpdateViewModel)
        {
            var Trainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (Trainer is null || EmailExist(Trainer.Email)|| PhoneExist(Trainer.Phone)) return false;

            Trainer.Email = trainerUpdateViewModel.Email;
            Trainer.Phone=trainerUpdateViewModel.Phone;
            Trainer.Address.City = trainerUpdateViewModel.City;
            Trainer.Address.Street = trainerUpdateViewModel.Street;
            Trainer.Address.BuldingNumber = trainerUpdateViewModel.BuildingNumber;
            Trainer.specialties = trainerUpdateViewModel.Specialties;
            Trainer.UpdateAt = DateTime.Now;
            _unitOfWork.GetRepository<Trainer>().update(Trainer);

            return _unitOfWork.SaveChanges() > 0;
            
               
        }



        #region CHECK Email and Phone unique 

        private bool EmailExist(string email)
        {
            return _unitOfWork.GetRepository<Trainer>().GetAll(x => x.Email == email).Any();
        }

        private bool PhoneExist(string phone)
        {
            return _unitOfWork.GetRepository<Trainer>().GetAll(x => x.Phone == phone).Any();
        }
        #endregion

        private bool ActiveSession (int id)
        {
            var check = _unitOfWork.GetRepository<Session>().GetAll(x => x.Id == id
            && x.CreatedAt >= DateTime.Now).Any();

            return check;
        }
    }
}
