using System;
using System.Data.Entity;
using DAL.Interfaces;
using NLog;

namespace DAL
{
    public class UOW : IUOW, IDisposable
    {
        private readonly string _instanceId = Guid.NewGuid().ToString();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UOW(IEFRepositoryProvider repositoryProvider, IDbContext dbContext)
        {
            _logger.Info("_instanceId: " + _instanceId);

            DbContext = dbContext;

            repositoryProvider.DbContext = dbContext;
            RepositoryProvider = repositoryProvider;
        }

        private IDbContext DbContext { get; set; }
        protected IEFRepositoryProvider RepositoryProvider { get; set; }

        // UoW main feature - atomic commit at the end of work
        public void Commit()
        {
            ((DbContext) DbContext).SaveChanges();
        }

        //standard repos
        //public IEFRepository<User> Owners { get { return GetStandardRepo<User>(); } }
        //public IEFRepository<Role> Roles { get { return GetStandardRepo<Role>(); } }
        //public IEFRepository<UserClaim> UserClaims { get { return GetStandardRepo<UserClaim>(); } }
        //public IEFRepository<UserLogin> UserLogins { get { return GetStandardRepo<UserLogin>(); } }

        // repo with custom methods
        // add it also in EFRepositoryFactories.cs, in method GetCustomFactories
        public IOwnerRepository Owners
        {
            get { return GetRepo<IOwnerRepository>(); }
        }

        public IPetRepository Pets
        {
            get { return GetRepo<IPetRepository>(); }
        }

        // calling standard EF repo provider
        private IEFRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        // calling custom repo provier
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _logger.Info("Disposing: " + disposing + " _instanceId: " + _instanceId);
        }

        #endregion
    }
}