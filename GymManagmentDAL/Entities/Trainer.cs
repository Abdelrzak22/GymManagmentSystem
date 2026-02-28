using GymManagmentDAL.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    public class Trainer:GymUser
    {
        //Hire Date==created at
        public Specialties specialties {  get; set; }

        public ICollection<Session> sessionss { get; set; } = null!;

    }
}
