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
    public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseEntity
    {

        private readonly GymdbContext _gymContext;
        public GeneralRepository(GymdbContext ggymContext)
        {
            _gymContext = ggymContext;
        }
        public int Add(T entity)
        {
            _gymContext.Set<T>().Add(entity);
            return _gymContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _gymContext.Set<T>().Remove(entity);
            return _gymContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _gymContext.Set<T>().ToList();

        }

        public T? GetById(int id)
        {
            return _gymContext.Set<T>().Find(id);
        }

        public int update(T entity)
        {
            _gymContext.Set<T>().Update(entity);
            return _gymContext.SaveChanges();
        }
    }
}
