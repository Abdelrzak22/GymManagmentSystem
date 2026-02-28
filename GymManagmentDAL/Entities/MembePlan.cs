using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    internal class MembePlan:BaseEntity
    {
        //startDate == CreatedAt

        public DateTime EndDate { get; set; }

       //to tell me if the plan expired or not 
       public string Status
        {
            get
            {
                if (EndDate >= DateTime.Now)
                    return "Expired";
                else
                    return "Active";
            }
        }


        #region  member => memberplan

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
        #endregion

        #region  plan => memberplan

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;
        #endregion
    }
}
