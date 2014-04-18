using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CultureController : Controller
    {
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            var langCookie = new HttpCookie("lang", lang) { HttpOnly = true };
            Session["lang"] = lang;
            return Redirect(returnUrl);
        }
    }
}
