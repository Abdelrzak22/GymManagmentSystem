using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Classes
{
    internal class TrainerRepository : ITrainerRepository
    {

        private readonly GymdbContext _gymContext;
        public TrainerRepository(GymdbContext ggymContext)
        {
            _gymContext = ggymContext;
        }
        public int Add(Trainer trainer)
        {
            _gymContext.Trainers.Add(trainer);
            return _gymContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var member = _gymContext.Trainers.Find(id);
            if (member is null) return 0;
            return _gymContext.SaveChanges();
        }

        public IEnumerable<Trainer> GetAll()
        {
            return _gymContext.Trainers.ToList();

        }

        public Trainer GetById(int id)
        {
            return _gymContext.Trainers.Find(id);
        }

        public int update(Trainer trainer)
        {
            _gymContext.Trainers.Update(trainer);
            return _gymContext.SaveChanges();
        }
    }
}
