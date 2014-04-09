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

        public DbSet<MasterCode> MasterCodeList { get; set; }
        public DbSet<Permission> PermissionList { get; set; }
        public DbSet<Module> ModuleList { get; set; }
        public DbSet<Menu> MenuList { get; set; }
        public DbSet<Tagging> TaggingList { get; set; }

        public DbSet<Account> AccountList { get; set; }
        public DbSet<AccountProfile> AccountProfileList { get; set; }
        public DbSet<AccountRole> AccountRoleList { get; set; }
        public DbSet<AccountInRole> AccountInRoleList { get; set; }

        public DbSet<Article> ArticleList { get; set; }
        public DbSet<ArticleTagging> ArticleTaggingList { get; set; }
        public DbSet<ArticleCategory> ArticleCategoryList { get; set; }
        public DbSet<ArticleAttachment> ArticleAttachmentList { get; set; }
        public DbSet<ArticleComment> ArticleCommentList { get; set; }

        public DbSet<Product> ProductList { get; set; }
        public DbSet<ProductTagging> ProductTaggingList { get; set; }
        public DbSet<ProductCategory> ProductCategoryList { get; set; }
        public DbSet<ProductAttachment> ProductAttachmentList { get; set; }
        public DbSet<ProductComment> ProductCommentList { get; set; }
    }
}