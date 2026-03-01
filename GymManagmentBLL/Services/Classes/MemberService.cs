using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.MemberViewModel;
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
    internal class MemberService : IMemberService
    {

        private readonly IGeneralRepository<Member> _General;
        private readonly IGeneralRepository<MembePlan> _memberplan;
        private readonly IPlanRepository _plan;
        private readonly IGeneralRepository<HealthRecord> _heath;
        private readonly IGeneralRepository<MemberBookSession> _membersession;

        public MemberService(IGeneralRepository<Member> GeneralRepository,IGeneralRepository<MembePlan> membeplan,IPlanRepository plan,
            IGeneralRepository<HealthRecord> heath,IGeneralRepository<MemberBookSession> membersession)
        {
            _General = GeneralRepository;
            _memberplan = membeplan;
            _plan = plan;
            _heath = heath;
            _membersession = membersession;
        }

        public bool Creat(CreateMemberViewModel createmodel)
        {
            try
            {



                //if exists return false
                if (EmailExist(createmodel.Email) || PhoneExist(createmodel.Phone))
                    return false;


                //add member   must convert from createviemmodel to member entity 

                var member = new Member
                {
                    Email = createmodel.Email,
                    Phone = createmodel.Phone,
                    Name = createmodel.Name,
                    Gender = createmodel.Gender,
                    Dateofbirth = createmodel.DateOfBirth,
                    Address = new Address()
                    {
                        BuldingNumber = createmodel.BuildingNumber,
                        Street = createmodel.Street,
                        City = createmodel.City
                    },
                    HealthRecord = new HealthRecord()
                    {
                        Height = createmodel.healthRecordViewModel.Height,
                        Weight = createmodel.healthRecordViewModel.Weight,
                        BloodType = createmodel.healthRecordViewModel.BloodType,
                        Note = createmodel.healthRecordViewModel.Note
                    }

                };

                return _General.Add(member) > 0;
            }
            catch (Exception )
            {
                return false;

            }
        }

        public bool Delete(int memberId)
        {
            var member = _General.GetById(memberId);
            if (member == null) return false;
            var ActiveMemberSession = _membersession.GetAll(x => x.Id == memberId && x.Session.CreatedAt > DateTime.Now).Any();
            if (ActiveMemberSession) return false;

            try
            {
                var memberPlan = _memberplan.GetAll(x => x.Id == memberId);
                if(memberPlan.Any())
                {
                    foreach(var item in memberPlan)
                    {
                        _memberplan.Delete(item);   
                    }

                   
                }
                return _General.Delete(member) > 0;

            }
            catch
            {
                return false;
            }


        }

        public MemberToUpdateViewModel? GetDataToUpdate(int MemberId)
        {
            var memberdata=_General.GetById(MemberId);
            if (memberdata is null)
                return null;
            return new MemberToUpdateViewModel()
            {
                Email = memberdata.Email,
                Phone = memberdata.Phone,
                Photo = memberdata.Photo,
                Name = memberdata.Name,
                BuildingNumber = memberdata.Address.BuldingNumber,
                Street = memberdata.Address.Street,
                City = memberdata.Address.City

            };
        }

        public HealthRecordViewModel? GetHealthRecordViewModel(int MemberId)
        {
            var HealthDetails = _heath.GetById(MemberId);
            if (HealthDetails is null)
                return null;
            return new HealthRecordViewModel()
            {
                Height=HealthDetails.Height,
                Weight=HealthDetails.Weight,
                Note=HealthDetails.Note,
                BloodType=HealthDetails.BloodType

            };
        }

        public MemberViewModel? GetMemberDetails(int MemberId)
        {
            var Member = _General.GetById(MemberId);
            if (Member is null)
                return null;
            var memberview = new MemberViewModel()
            {
                Phone = Member.Phone,
                Name = Member.Name,
                Email = Member.Email,
                Gender = Member.Gender.ToString(),
                DateOfBirth = Member.Dateofbirth.ToShortDateString(),
                Address=$"{Member.Address.BuldingNumber}-{Member.Address.Street}-{Member.Address.City}",

            };

            var ActiveMemberShip = _memberplan.GetAll(z => z.Id == MemberId && z.Status == "Active").FirstOrDefault();
            if(ActiveMemberShip is not null)
            {
                memberview.MemberShipStartDate = ActiveMemberShip.CreatedAt.ToShortDateString();
                memberview.MemberShipEndDate=ActiveMemberShip.EndDate.ToShortDateString() ;
                var plan = _plan.GetById(ActiveMemberShip.PlanId);
                memberview.PlanName = plan?.Name;
            }

            return memberview;

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

        public bool Update(MemberToUpdateViewModel member, int MemberId)
        {
            try
            {
                if(EmailExist(member.Email) || PhoneExist(member.Phone) )
                    return false;
                var memberdata = _General.GetById(MemberId);
                if(memberdata is null) return false;    

                memberdata.Email=member.Email;  
                memberdata.Phone=member.Phone;
                memberdata.UpdateAt = DateTime.Now;
                memberdata.Address.Street = member.Street;
                memberdata.Address.City = member.City;
                memberdata.Address.BuldingNumber=member.BuildingNumber;

                return _General.update(memberdata) > 0;



                   

            }
            catch(Exception)
            {
                return false;
            }
        }


        #region CHECK Email and Phone unique 

        private bool EmailExist (string email)
        {
            return _General.GetAll(x=>x.Email==email).Any();
        }

        private bool PhoneExist(string phone)
        {
            return _General.GetAll(x => x.Phone == phone).Any();
        }
        #endregion
    }
}
