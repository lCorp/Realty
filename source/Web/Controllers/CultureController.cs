using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Models;
using Core.Persistence;
using Core.Constant;

namespace Web.Controllers
{
    public class CultureController : Controller
    {
        private readonly Context _context = new Context();

        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            List<CodeMaster> cultureList = this._context.CodeMasterList.Where(m => m.CodeMasterType == "Culture").OrderBy(m => m.Ordinal).ToList();
            return View(cultureList);
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            HttpCookie langCookie = new HttpCookie("lang", lang) { HttpOnly = true };
            langCookie.Expires = DateTime.Now.AddDays(GlobalConstant.PERMANENT_COOKIES_EXPERATION);
            Response.AppendCookie(langCookie);
            return Redirect(returnUrl);
        }
    }
}
