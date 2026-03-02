using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.PlanViewModel;
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
    internal class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<PlanViewModel> GetAll()
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetAll();
            if (plan == null || !plan.Any()) return [];
            return plan.Select(p => new PlanViewModel
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price,
                DurationDays = p.DurationDays,
                IsActive = p.IsActive
            });
        }

        public PlanViewModel? GetById(int PlanId)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(PlanId);
            if (plan is null) return null;
            return new PlanViewModel()
            {
                Id = plan.Id,
                Description = plan.Description,
                Name = plan.Name,
                DurationDays = plan.DurationDays,
                IsActive = plan.IsActive,
                Price = plan.Price,
            };


        }

        public PlanToUpdate? GetPlanToUpdate(int PlanId)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(PlanId);
            if (plan is null || plan.IsActive == false || HasMemberShip(PlanId)) return null;
            return new PlanToUpdate()
            {
                Description = plan.Description,
                Price = plan.Price,
                PlanName = plan.Name,
                DurationDays = plan.DurationDays
            };
        }

        public bool IsPlanUpdate(int PlanId, PlanToUpdate plan)
        {
            var plandata = _unitOfWork.GetRepository<Plan>().GetById(PlanId);
            if (plandata is null || HasMemberShip(PlanId)) return false;

             (plandata.Price, plandata.DurationDays, plandata.Description, plandata.CreatedAt) =
                (plan.Price, plan.DurationDays, plan.Description, DateTime.Now);

            _unitOfWork.GetRepository<Plan>().update(plandata);
            return _unitOfWork.SaveChanges() > 0;

        }

        public bool ToggleStatus(int PlanId)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(PlanId);
            if (plan is null || HasMemberShip(PlanId)) return false;

            plan.IsActive = plan.IsActive == true ? false : true;
            plan.UpdateAt = DateTime.Now;

            try
            {
                _unitOfWork.GetRepository<Plan>().update(plan);
                return _unitOfWork.SaveChanges() > 0;

            }
            catch
            {
                return false;
            }
        }


        #region 

        public bool HasMemberShip(int PlanId)
        {
            var memberPlan = _unitOfWork.GetRepository<MembePlan>().GetAll(x => x.PlanId == PlanId && x.Status == "Active");
            if (memberPlan is null) return false;
            return memberPlan.Any();
        }
        #endregion
    }
}
