using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Classes
{
    public class SessionRepository : GeneralRepository<Session>, ISessionRepository
    {
        private readonly GymdbContext _dbcontext;

        public SessionRepository(GymdbContext dbcontext) : base(dbcontext)  
        {
            _dbcontext = dbcontext;
        }
        public int BookingSession(int id)
        {
           return _dbcontext.memberBookSessions.Count(x=>x.Id == id);   
        }

        public IEnumerable<Session> GetAllSessionWithTrainerAndCategoty()
        {
            return _dbcontext.Sessions.Include(x=>x.trainer).Include(y=>y.Category).ToList();
        }

        public Session? GetSessionWithTrainerAndCategory(int SessionId)
        {
            return _dbcontext.Sessions.Include(x => x.trainer).Include(y => y.Category).FirstOrDefault(z=>z.Id==SessionId);

        }
    }
}
