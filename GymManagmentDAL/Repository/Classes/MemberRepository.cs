using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Classes
{
    internal class MemberRepository : IMemberRepository
    {

        private readonly GymdbContext _gymContext= new GymdbContext();
        public int Add(Member member)
        {
           _gymContext.Members.Add(member);
            return _gymContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var member = _gymContext.Members.Find(id);
            if (member is null) return 0;
            return _gymContext.SaveChanges();
        }

        public IEnumerable<Member> GetAll()
        {
            return _gymContext.Members.ToList();

        }

        public Member GetById(int id)
        {
            return _gymContext.Members.Find(id);
        }

        public int update(Member member)
        {
            _gymContext.Members.Update(member);
            return _gymContext.SaveChanges();
        }
    }
}
