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
    //public class UnitOfWork : IUnitOfWork
    //{
    //    private readonly GymdbContext _dbcontext;
    //    private readonly ISessionRepository _sessionRepository;
    //    private readonly Dictionary<Type, object> _repository = new();
    //    public UnitOfWork(GymdbContext gymdbContext,ISessionRepository sessionRepository)
    //    {
    //        _dbcontext = gymdbContext;
    //        _sessionRepository = sessionRepository;
    //    }

    //    public ISessionRepository sessionRepository { get; }

    //    public IGeneralRepository<T> GetRepository<T>() where T : BaseEntity, new()
    //    {
    //        var EntityType= typeof(T);
    //        if(_repository.TryGetValue(EntityType, out var repository))
    //            return (IGeneralRepository<T>)repository;

    //        var NewRepo = new GeneralRepository<T>(_dbcontext);
    //        _repository.Add(EntityType, NewRepo);
    //        return NewRepo;


    //    }

    //    public int SaveChanges()
    //    {
    //        return _dbcontext.SaveChanges();
    //    }
    //}
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymdbContext _dbcontext;
        private readonly Dictionary<Type, object> _repository = new();

        public UnitOfWork(GymdbContext gymdbContext, ISessionRepository sessionRepository)
        {
            _dbcontext = gymdbContext;
            this.sessionRepository = sessionRepository; // الحل هنا
        }

        public ISessionRepository sessionRepository { get; }

        public IGeneralRepository<T> GetRepository<T>() where T : BaseEntity, new()
        {
            var EntityType = typeof(T);

            if (_repository.TryGetValue(EntityType, out var repository))
                return (IGeneralRepository<T>)repository;

            var NewRepo = new GeneralRepository<T>(_dbcontext);
            _repository.Add(EntityType, NewRepo);

            return NewRepo;
        }

        public int SaveChanges()
        {
            return _dbcontext.SaveChanges();
        }
    }
}
