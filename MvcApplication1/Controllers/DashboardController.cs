using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.DbModels;
using MvcApplication1.Filters;

namespace MvcApplication1.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/
        public ActionResult Index(string Title)
        {
            ViewBag.Message = "DashBoard";
            MvcApplication.logger.Info("Open dashboard from {0} at {1} with title = {2}", WebSecurity.UserLogin, DateTime.Now, Title);
            var directory = new DirectoryInfo(Server.MapPath(@"~\App_Data\" + WebSecurity.UserLogin + @"\" + Title));
            if (!directory.Exists)
            {
                directory.Create();
            }
            ViewBag.files = directory.GetFiles().ToList();
            ViewBag.subDirectoryList = directory.GetDirectories().ToList();
            ViewBag.path = @"~\App_Data\" + WebSecurity.UserLogin + @"\" + Title;
          
            return View();
        }
     

    }
}
