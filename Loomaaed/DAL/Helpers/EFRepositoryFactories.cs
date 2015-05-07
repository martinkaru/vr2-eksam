using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Repositories;
using NLog;

namespace DAL.Helpers
{
    public class EFRepositoryFactories : IDisposable
    {
        private readonly string _instanceId = Guid.NewGuid().ToString();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IDictionary<Type, Func<IDbContext, object>> _repositoryFactories;

        public EFRepositoryFactories()
        {
            _logger.Info("_instanceId: " + _instanceId);

            _repositoryFactories = GetCustomFactories();
        }

        //this ctor is for testing only, you can give here an arbitrary list of repos
        public EFRepositoryFactories(IDictionary<Type, Func<IDbContext, object>> factories)
        {
            _logger.Info("_instanceId: " + _instanceId);

            _repositoryFactories = factories;
        }

        public void Dispose()
        {
            _logger.Info("_instanceId: " + _instanceId);
        }

        //special repos with custom interfaces are registered here
        private static IDictionary<Type, Func<IDbContext, object>> GetCustomFactories()
        {
            return new Dictionary<Type, Func<IDbContext, object>>
            {
                {typeof (IOwnerRepository), dbContext => new OwnerRepository(dbContext)},
                {typeof (IPetRepository), dbContext => new PetRepository(dbContext)}
            };
        }

        public Func<IDbContext, object> GetRepositoryFactory<T>()
        {
            Func<IDbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof (T), out factory);
            return factory;
        }

        public Func<IDbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            // if we already have this repository in list, return it
            // if not, create new instance of EFRepository
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<IDbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            // create new instance of EFRepository<T>
            return dbContext => new EFRepository<T>(dbContext);
        }
    }
}