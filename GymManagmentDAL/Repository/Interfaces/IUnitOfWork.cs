using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGeneralRepository<T> GetRepository<T>() where T : BaseEntity, new();

        int SaveChanges();
    }
}
