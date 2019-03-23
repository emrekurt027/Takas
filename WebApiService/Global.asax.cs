using Autofac;
using Autofac.Integration.WebApi;
using Data;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiService.Controllers;

namespace WebApiService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            ///OperationsView ajax ile webapiye denemeler yapmak adına oluşturuldu. Şu an için login ve register olayları çalışıyor,
            ///Ama Cookie ile login olma olayı ayarlı değil, düzeltilecek.

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataOperations.InitDatabase();


            var builder = new ContainerBuilder();
            builder.RegisterType<ProductController>().InstancePerRequest();
            builder.RegisterType<BaseService<Common.Domains.Product>>().InstancePerRequest();
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
