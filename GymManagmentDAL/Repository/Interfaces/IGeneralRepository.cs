using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    public interface IGeneralRepository<T> where T : BaseEntity
    {

        //get all
        IEnumerable<T> GetAll(Func<T,bool>? condition=null);
        //get by id
        T? GetById(int id);
        //add
        void Add(T entity);
        //update
        void update(T entity);
        //delete
        void Delete(T entity);

    }
}
