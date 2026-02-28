using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    internal interface ITrainerRepository
    {
        //get all
        IEnumerable<Trainer> GetAll();
        //get by id
        Trainer GetById(int id);
        //add
        int Add(Trainer trainer);
        //update
        int update(Trainer trainer);
        //delete
        int Delete(int id);
    }
}
