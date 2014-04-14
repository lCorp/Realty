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
        private const string _defaultConnectionName = Constant.DEFAULT_CONNECTION_NAME;

        public Context()
            : base(_defaultConnectionName)
        {

        }

        public Context(string connectionName)
            : base(connectionName)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            MigrateDatabaseToLatestVersion<Context, Configuration> migrateDatabaseConfiguration = new MigrateDatabaseToLatestVersion<Context, Configuration>();
            Database.SetInitializer(migrateDatabaseConfiguration);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MasterCode> MasterCodeList { get; set; }

        public DbSet<Module> ModuleList { get; set; }
        public DbSet<ModuleInMenu> MenuList { get; set; }
        public DbSet<ModulePermission> PermissionList { get; set; }

        public DbSet<Account> AccountList { get; set; }
        public DbSet<AccountTransaction> AccountTransactionList { get; set; }
        public DbSet<AccountRole> AccountRoleList { get; set; }
        public DbSet<AccountInRole> AccountInRoleList { get; set; }

        public DbSet<Article> ArticleList { get; set; }
        public DbSet<ArticleAttachment> ArticleAttachmentList { get; set; }
        public DbSet<ArticleComment> ArticleCommentList { get; set; }
        public DbSet<ArticleTag> ArticleTagList { get; set; }
        public DbSet<ArticleInTag> ArticleInTagList { get; set; }
        public DbSet<ArticleCategory> ArticleCategoryList { get; set; }     

        public DbSet<Product> ProductList { get; set; }
    }
}