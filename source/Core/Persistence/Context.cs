using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Core.Persistence
{
    public class Context : DbContext
    {
        private const string _defaultConnectionStringName = "DefaultConnection";

        public Context()
            : base(_defaultConnectionStringName)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            MigrateDatabaseToLatestVersion<Context, Configuration> migrateDatabaseConfiguration = new MigrateDatabaseToLatestVersion<Context, Configuration>();
            Database.SetInitializer(migrateDatabaseConfiguration);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Accounts { get; set; }
    }
}