using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    internal class Category:BaseEntity
    {
        public string CategoryName { get; set; } = null!;

        #region  relation between category and session

        public ICollection<Session> Sessions { get; set; }  =null!; 
        #endregion
    }
}
