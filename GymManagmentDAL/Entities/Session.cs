using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    internal class Session:BaseEntity
    {
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public DateTime EndDate { get; set; }

        #region  relation between category and session

        public int CategoryId { get; set; }

        public Category Category { get; set; }=null!;
        #endregion


        #region part1 (session and member book session)


       public ICollection<MemberBookSession> MemberBookSession1 { get; set; }
        #endregion
    }
}
