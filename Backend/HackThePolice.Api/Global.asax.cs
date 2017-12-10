using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ExpressMapper;
using HackThePolice.Api.Models;
using HackThePolice.Infrastructure.Core.Models;

namespace HackThePolice.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Register<Incident, IncidentModel>();
            Mapper.Register<Incident, Incident>();
            Mapper.Register<IncidentModel, Incident>();
            Mapper.Register<Statement, StatementModel>();
            Mapper.Register<StatementModel, Statement>();
            Mapper.Register<Statement, Statement>();
            Mapper.Compile();
        }
    }
}
