using GymManagmentBLL.ViewModels.TrainerViewModel;
using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Interfaces
{
    public interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetTrainers();
        bool CreateTrainer (CreateTrainerVIewModel model);
        TrainerViewModel? GetById(int TrainerId);

        TrainerUpdateViewModel? GetDataToUpdate(int TrainerId);
        bool Update(int TrainerId,TrainerUpdateViewModel trainerUpdateViewModel);
        bool Delete (int TrainerId);
    }
}
