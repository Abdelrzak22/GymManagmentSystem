using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    internal interface IGeneralRepository<T> where T : BaseEntity
    {

        //get all
        IEnumerable<T> GetAll();
        //get by id
        T? GetById(int id);
        //add
        int Add(T entity);
        //update
        int update(T entity);
        //delete
        int Delete(T entity);

    }
}
