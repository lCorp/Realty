using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using Core.Models;
using Core.Utils;
using Core.Constant;

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
            //Account
            context.AccountList.AddOrUpdate(m => m.Id,
                new Account { Id = CrytographyUtil.StringToGuid("Account:" + GlobalConstant.ACCOUNT_HOST_NAME), AccountName = GlobalConstant.ACCOUNT_HOST_NAME, Password = CrytographyUtil.GetHashToString(GlobalConstant.ACCOUNT_HOST_NAME), LanguageCulture = "vi-VN" });

            //CodeMaster
            context.CodeMasterList.AddOrUpdate(m => m.Id,
                new CodeMaster { Id = CrytographyUtil.StringToGuid("CodeMaster:Common|WebsiteName"), CodeMasterType = "Common", CodeMasterCode = "WebsiteName", CodeMasterValue = "Miền Đất Mới", LocalizedValue = "Miền Đất Mới" });

            context.CodeMasterList.AddOrUpdate(m => m.Id,
                new CodeMaster { Id = CrytographyUtil.StringToGuid("CodeMaster:Culture|en-US"), CodeMasterType = "Culture", CodeMasterCode = "en-US", CodeMasterValue = "English", LocalizedValue = "English" },
                new CodeMaster { Id = CrytographyUtil.StringToGuid("CodeMaster:Culture|vi-VN"), CodeMasterType = "Culture", CodeMasterCode = "vi-VN", CodeMasterValue = "Vietnames", LocalizedValue = "Tiếng Việt" });

            context.CodeMasterList.AddOrUpdate(m => m.Id,
                new CodeMaster { Id = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|Country"), CodeMasterType = "EditableCode", CodeMasterCode = "Country", CodeMasterValue = "Country", LocalizedValue = "Quốc Gia", Level = 0, Ordinal = 0 },
                new CodeMaster { Id = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|City"), ParentId = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|Country"), CodeMasterType = "EditableCode", CodeMasterCode = "City", CodeMasterValue = "City", LocalizedValue = "Tỉnh | Thành Phố", Level = 1, Ordinal = 1 },
                new CodeMaster { Id = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|District"), ParentId = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|City"), CodeMasterType = "EditableCode", CodeMasterCode = "District", CodeMasterValue = "Ward", LocalizedValue = "Quận | Huyện", Level = 2, Ordinal = 2 });

            //Module
            context.ModuleList.AddOrUpdate(m => m.Id,
                new Module { Id = CrytographyUtil.StringToGuid("Module:Product|Index"), ControllerName = "Product", ActionName = "Index" },
                new Module { Id = CrytographyUtil.StringToGuid("Module:Article|Index"), ControllerName = "Article", ActionName = "Index" },
                new Module { Id = CrytographyUtil.StringToGuid("Module:Account|Index"), ControllerName = "Account", ActionName = "Index" },
                new Module { Id = CrytographyUtil.StringToGuid("Module:CodeMaster|Index"), ControllerName = "CodeMaster", ActionName = "Index" },
                new Module { Id = CrytographyUtil.StringToGuid("Module:Menu|Index"), ControllerName = "Menu", ActionName = "Index" });

            //Mennu Back End
            context.ModuleInMenuList.AddOrUpdate(m => m.Id,
                new ModuleInMenu { Id = CrytographyUtil.StringToGuid("Menu:ManageProduct"), Type = "ModuleBased", MenuCategory = "BackEnd", MenuName = "Bất Động Sản", ModuleId = CrytographyUtil.StringToGuid("Module:Product|Index"), Level = 0, Ordinal = 0 },
                new ModuleInMenu { Id = CrytographyUtil.StringToGuid("Menu:ManageArticle"), Type = "ModuleBased", MenuCategory = "BackEnd", MenuName = "Bài Viết", ModuleId = CrytographyUtil.StringToGuid("Module:Article|Index"), Level = 0, Ordinal = 1 },
                new ModuleInMenu { Id = CrytographyUtil.StringToGuid("Menu:ManageAccount"), Type = "ModuleBased", MenuCategory = "BackEnd", MenuName = "Người Dùng", ModuleId = CrytographyUtil.StringToGuid("Module:Account|Index"), Level = 0, Ordinal = 2 },
                new ModuleInMenu { Id = CrytographyUtil.StringToGuid("Menu:ManageCodeMaster"), Type = "ModuleBased", MenuCategory = "BackEnd", MenuName = "Danh Mục Chung", ModuleId = CrytographyUtil.StringToGuid("Module:CodeMaster|Index"), Level = 4, Ordinal = 3 },
                new ModuleInMenu { Id = CrytographyUtil.StringToGuid("Menu:ManageMenu"), Type = "ModuleBased", MenuCategory = "BackEnd", MenuName = "Tùy Chỉnh Mennu", ModuleId = CrytographyUtil.StringToGuid("Module:Menu|Index"), Level = 0, Ordinal = 5 });

            //Localization
            context.LocalizationList.AddOrUpdate(m => m.Id,
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageProduct|vi-VN"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageProduct"), LanguageCulture = "vi-VN", Value = "Bất Động Sản" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageProduct|en-US"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageProduct"), LanguageCulture = "en-US", Value = "Real Estate" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageArticle|vi-VN"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageArticle"), LanguageCulture = "vi-VN", Value = "Bài Viết" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageArticle|en-US"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageArticle"), LanguageCulture = "en-US", Value = "Article" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageAccount|vi-VN"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageAccount"), LanguageCulture = "vi-VN", Value = "Người Dùng" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageAccount|en-US"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageAccount"), LanguageCulture = "en-US", Value = "User Account" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageCodeMaster|vi-VN"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageCodeMaster"), LanguageCulture = "vi-VN", Value = "Danh Mục Chung" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageCodeMaster|en-US"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageCodeMaster"), LanguageCulture = "en-US", Value = "Master Data" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageMenu|vi-VN"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageMenu"), LanguageCulture = "vi-VN", Value = "Tùy Chỉnh Menu" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:Mennu:ManageMenu|en-US"), RecordId = CrytographyUtil.StringToGuid("Menu:ManageMenu"), LanguageCulture = "en-US", Value = "Menu Configuration" });

            context.LocalizationList.AddOrUpdate(m => m.Id,
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:CodeMaster:EditableCode|Country|vi-VN"), RecordId = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|Country"), LanguageCulture = "vi-VN", Value = "Quốc Gia" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:CodeMaster:EditableCode|Country|en-US"), RecordId = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|Country"), LanguageCulture = "en-US", Value = "Country" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:CodeMaster:EditableCode|City|vi-VN"), RecordId = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|City"), LanguageCulture = "vi-VN", Value = "Tỉnh | Thành Phố" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:CodeMaster:EditableCode|City|en-US"), RecordId = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|City"), LanguageCulture = "en-US", Value = "City" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:CodeMaster:EditableCode|District|vi-VN"), RecordId = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|District"), LanguageCulture = "vi-VN", Value = "Quận | Huyện" },
                new Localization { Id = CrytographyUtil.StringToGuid("Localization:CodeMaster:EditableCode|District|en-US"), RecordId = CrytographyUtil.StringToGuid("CodeMaster:EditableCode|District"), LanguageCulture = "en-US", Value = "District" });

            base.Seed(context);
        }
    }
}
