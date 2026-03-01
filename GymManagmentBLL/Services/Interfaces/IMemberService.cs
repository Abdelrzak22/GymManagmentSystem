using GymManagmentBLL.ViewModels.MemberViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Interfaces
{
    internal interface IMemberService
    {
        IEnumerable<MemberViewModel> GetMembers();
        bool Creat(CreateMemberViewModel createmodel);

        MemberViewModel? GetMemberDetails(int MemberId);

        HealthRecordViewModel? GetHealthRecordViewModel(int MemberId);
        MemberToUpdateViewModel? GetDataToUpdate(int MemberId);

        bool Update (MemberToUpdateViewModel member, int MemberId);
        bool Delete(int memberId);


    }
}
