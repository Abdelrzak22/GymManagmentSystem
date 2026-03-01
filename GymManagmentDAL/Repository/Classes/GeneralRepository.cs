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
    public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseEntity
    {

        private readonly GymdbContext _gymContext;
        public GeneralRepository(GymdbContext ggymContext)
        {
            _gymContext = ggymContext;
        }
        public void Add(T entity)
        {
            _gymContext.Set<T>().Add(entity);
            
        }

        public void Delete(T entity)
        {
            _gymContext.Set<T>().Remove(entity);
           
        }

        public IEnumerable<T> GetAll(Func<T, bool>? condition = null)
        {
            if (condition == null)
                return _gymContext.Set<T>().AsNoTracking().ToList();
            else
                return _gymContext.Set<T>().AsNoTracking().Where(condition).ToList();
        }

        public T? GetById(int id)
        {
            return _gymContext.Set<T>().Find(id);
        }

        public void update(T entity)
        {
            _gymContext.Set<T>().Update(entity);
            
        }
    }
}
