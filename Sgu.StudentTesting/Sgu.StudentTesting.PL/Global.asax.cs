using Ninject;
using Ninject.Web.Common.WebHost;
using Sgu.StudentTesting.PL.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sgu.StudentTesting.PL
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override Ninject.IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            Config.Config.RegisterServices(kernel);
             return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);     
            AutoMapperConfig.RegisterMaps(); // Call Register method on App_Start
        }
    }
}
