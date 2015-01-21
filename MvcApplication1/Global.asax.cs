using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using MvcApplication1.DbModels;
using WebMatrix.WebData;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static DataClasses1DataContext RepoContext = new DataClasses1DataContext();

        protected void Application_Start()
        {
            logger.Info("Application Start at {0}", DateTime.Now);
            //test();
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        public void test()
        {
            var db = new DataClasses1DataContext();
            var docs = db.Documents.AsEnumerable();
            var doc = docs.First();
            var tmp = doc.Path.Split('/');
            var project = tmp[0];
            var folder = tmp[1];
        }
    }
}