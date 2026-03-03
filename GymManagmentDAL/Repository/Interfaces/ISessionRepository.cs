using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    public interface ISessionRepository:IGeneralRepository<Session>
    {
        IEnumerable<Session> GetAllSessionWithTrainerAndCategoty();
        Session? GetSessionWithTrainerAndCategory(int SessionId);

        int BookingSession(int id);
    }
}
