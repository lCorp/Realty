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
            context.AccountList.AddOrUpdate(m => m.Id,
                new Account { Id = CrytographyUtil.StringToGuid(Constant.ACCOUNT_HOST_NAME), AccountName = Constant.ACCOUNT_HOST_NAME, Password = CrytographyUtil.GetHashToString(Constant.ACCOUNT_HOST_NAME) });

            base.Seed(context);
        }
    }
}
