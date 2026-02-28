using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    public class MemberBookSession:BaseEntity
    {

      //BookingDate == CreatedAt
        public bool IsAttended { get; set; }

        #region part1 (session and member book session)


        public int SessionId { get; set; }
        public Session Session { get; set; }
        #endregion

        #region part1 (session and member book session)


        public int MemberId { get; set; }
        public Member Member{ get; set; }
        #endregion


    }
}
