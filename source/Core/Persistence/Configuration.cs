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
                new Account { Id = 1, Name = "host", Password = CrytographyUtil.GetHash("host") });

            context.MasterCodeList.AddOrUpdate(m => m.Id,
                new MasterCode { Id = 1, Category = "Common", Code = "SiteName", Value = "MIỀN ĐẤT MỚI" },
                new MasterCode { Id = 2, Category = "Common", Code = "SiteSlogan", Value = "Niềm tin cho bạn" },
                new MasterCode { Id = 1, Category = "Common", Code = "Hotline", Value = "+84 98 458 21 88" },
                new MasterCode { Id = 1, Category = "Social", Code = "Email", Value = "ngohuuloc@gmail.com" },
                new MasterCode { Id = 1, Category = "Social", Code = "Facebook", Value = "https://www.facebook.com/" },
                new MasterCode { Id = 1, Category = "Social", Code = "Twitter", Value = "https://twitter.com/" },
                new MasterCode { Id = 1, Category = "Social", Code = "GooglePlus", Value = "https://plus.google.com" }
                );

            base.Seed(context);
        }
    }
}
