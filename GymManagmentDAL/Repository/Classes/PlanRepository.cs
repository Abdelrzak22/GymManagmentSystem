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
    internal class PlanRepository : IPlanRepository
    {
        private readonly GymdbContext _gymContext;
        public PlanRepository(GymdbContext ggymContext)
        {
            _gymContext = ggymContext;
        }
       

        public IEnumerable<Plan> GetAll()
        {
            return _gymContext.Plans.ToList();

        }

        public Plan? GetById(int id)
        {
            return _gymContext.Plans.Find(id);
        }

        public int update(Plan plan)
        {
            _gymContext.Plans.Update(plan);
            return _gymContext.SaveChanges();
        }
    }
}
