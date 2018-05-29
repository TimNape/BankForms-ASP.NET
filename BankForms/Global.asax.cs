using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Autofac.Integration.Web;
using Autofac;
using BankFormsDal.interfaces;
using BankFormsSql;

namespace BankForms
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }


        void Application_Start(object sender, EventArgs e)
        {

            log4net.Config.XmlConfigurator.Configure();

            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();
            builder.RegisterType<BankerBookingDal>().As<IBankerBookingDal>().InstancePerRequest();
            builder.RegisterType<LeadDal>().As<ILeadDal>().InstancePerRequest();

            // ... continue registering dependencies...


            // Once you're done registering things, set the container
            // provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());

            

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);            
        }
    }
}