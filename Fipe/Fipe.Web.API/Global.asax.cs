using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Fipe.IOC.NinjectConfiguration;
using Fipe.Repository.EntityFramework.DbContextManagement;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Fipe.Web.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new NinjectServiceLocator(new StandardKernel(new ApplicationModule()));
            ServiceLocator.SetLocatorProvider(() => container);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            FipeDbContextManager.BuildDbContext();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            FipeDbContextManager.CloseDbContext();
        }
    }
}
