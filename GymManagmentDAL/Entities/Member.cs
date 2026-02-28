using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    internal class Member:GymUser
    {
        // joinDate== createdat
        public string? Photo {  get; set; }

        #region relation between healthyrecord and member

        public HealthRecord HealthRecord { get; set; } = null!;
        #endregion

        #region part2 (member and member book session)


        public ICollection<MemberBookSession> MemberBookSession2 { get; set; } = null!;
        #endregion

        #region  member => memberplan

        public ICollection<MembePlan> Memberplanss { get; set; } = null!;
        #endregion

    }
}
