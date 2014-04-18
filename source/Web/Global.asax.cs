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
            HttpCookie languageCookie = HttpContext.Current.Request.Cookies["lang"];
            if (languageCookie != null)
            {
                cultureName = languageCookie.Value;
            }
            else
            {
                string languageSession = (string)Session["lang"];
                if (!string.IsNullOrEmpty(languageSession))
                {
                    cultureName = languageSession;
                }
                else
                {
                    string[] userLanguages = HttpContext.Current.Request.UserLanguages;
                    if (userLanguages != null && userLanguages.Count() > 0)
                    {
                        cultureName = userLanguages[0];
                    }
                }
            }
            CultureInfo cultureInfo = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}