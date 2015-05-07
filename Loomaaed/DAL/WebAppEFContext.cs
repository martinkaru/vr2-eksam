using System;
using System.Data.Entity;
using DAL.Interfaces;
using Domain.Models;
using NLog;

namespace DAL
{
    public class WebAppEFContext : DbContext, IDbContext, IDisposable
    {
        private readonly string _instanceId = Guid.NewGuid().ToString();
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public WebAppEFContext()
            : base("Name=WebAppNoEFConnection")
        {
            _logger.Info("_instanceId: " + _instanceId);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WebAppEFContext>());
        }

        // Identity tables
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        
        protected override void Dispose(bool disposing)
        {
            _logger.Info("Disposing: " + disposing + " _instanceId: " + _instanceId);
            base.Dispose(disposing);
        }
    }
}