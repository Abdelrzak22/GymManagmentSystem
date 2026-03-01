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
        public MemberService(IGeneralRepository<Member> GeneralRepository)
        {
            _General = GeneralRepository;
        }

        public bool Creat(CreateMemberViewModel createmodel)
        {
            try
            {


                // if email exist
                var Emailexist = _General.GetAll(x => x.Email == createmodel.Email).Any();


                // if phone exist
                var PhoneExist = _General.GetAll(x => x.Phone == createmodel.Phone).Any();

                //if exists return false
                if (Emailexist || PhoneExist)
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
            catch (Exception ex)
            {
                return false;

            }
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
