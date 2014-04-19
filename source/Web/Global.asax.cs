using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.Constant;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            string cultureName = GlobalConstant.DEFAULT_CULTURE_NAME;
            //Get culture from cookies
            HttpCookie languageCookie = HttpContext.Current.Request.Cookies["lang"];
            if (languageCookie != null)
            {
                cultureName = languageCookie.Value;
            }
            //Get culture based on user account setting
            else if (User.Identity.IsAuthenticated)
            {
                using (Core.Persistence.Context context = new Core.Persistence.Context())
                {
                    Core.Models.Account account = context.AccountList.FirstOrDefault(m => m.AccountName == User.Identity.Name);
                    if (account != null && !string.IsNullOrEmpty(account.LanguageCulture))
                    {
                        cultureName = account.LanguageCulture;
                        //Write this setting to cookies for better performance in next request
                        HttpCookie langCookie = new HttpCookie("lang", cultureName) { HttpOnly = true };
                        langCookie.Expires = DateTime.Now.AddYears(100);
                        Response.AppendCookie(langCookie);
                    }
                }
            }
            //Get culture by client browser
            else
            {
                string[] userLanguages = HttpContext.Current.Request.UserLanguages;
                if (userLanguages != null && userLanguages.Count() > 0)
                {
                    cultureName = userLanguages[0];
                }
            }
            CultureInfo cultureInfo = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}