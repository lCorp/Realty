using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using Core.Models;
using Core.Utils;

namespace Core.Persistence
{
    public class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context context)
        {
            context.Accounts.AddOrUpdate(m => m.Id,
                new Account { Id = 1, Name = "host", NickName = "Supper Admin", Password = CrytographyUtil.GetHash("host") });

            base.Seed(context);
        }
    }
}
