using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.MemberViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Classes
{
    internal class MemberService : IMemberService
    {

        private readonly IGeneralRepository<Member> _General;
        public MemberService(IGeneralRepository<Member> GeneralRepository)
        {
            _General = GeneralRepository;
        }
        public IEnumerable<MemberViewModel> GetMembers()
        {
            var member = _General.GetAll();
            if (member is null || !member.Any()) return [];
            var members = member.Select(x => new MemberViewModel            //to convert normal member to member view model with only data needed
            {
                Name = x.Name,
                Id = x.Id,
                Phone = x.Phone,
                Photo = x.Photo,
                Gender = x.Gender.ToString(),
                Email = x.Email
            });
            return members;
        }
    }
}
