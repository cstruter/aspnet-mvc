using CSTruter.Mvc.Samples.Sample2.Providers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CSTruter.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
           // ModelMetadataProviders.Current = new ResourceTypeModelMetadataProvider();
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
