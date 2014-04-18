using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Persistence;

namespace Core.Models
{
    public class ModuleInMenu : BaseEntity
    {
        private Context _context = new Context();

        public string MenuCategory { get; set; }
        public string MenuName { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? ModuleId { get; set; }
        public string TargetUrl { get; set; }
        public string Parameter { get; set; }
        public int Level { get; set; }
        public int Ordinal { get; set; }

        #region Methods

        public static List<ModuleInMenu> GetMenuList(string menuCategory)
        {
            List<ModuleInMenu> result = new List<ModuleInMenu>();
            using (Context context = new Context())
            {
                result = context.ModuleInMenuList.Where(m => m.MenuCategory == menuCategory).OrderBy(m => m.Ordinal).ToList();
            }
            return result;
        }

        public string GetTargetUrl()
        {
            string result = "#";
            if (this.Type == "ModuleBased")
            {
                Module module = _context.ModuleList.FirstOrDefault(m => m.Id == this.ModuleId);
                if (module != null)
                {
                    result = string.Format("{0}/{1}/{2}", module.ControllerName, module.ActionName, this.Parameter);
                }
            }
            else if (this.Type == "UrlBased")
            {
                result = this.TargetUrl;
            }
            return result;
        }

        #endregion
    }
}