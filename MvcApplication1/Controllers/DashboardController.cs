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
        private Entities db = MvcApplication.RepoContext;
        public NLog.Logger Log = MvcApplication.logger;
        //
        // GET: /Dashboard/
        public ActionResult Index(int id)
        {
            Projects project = db.Projects.Find(id);
            Log.Info("Dashboard fid project by id:{0}", id);

            if (project!=null)
            {
                ViewBag.Message = "DashBoard";
                MvcApplication.logger.Info("Open dashboard from {0} at {1} with title = {2}", WebSecurity.UserLogin, DateTime.Now, project.Title);

                ViewBag.path = @"~\App_Data\" + project.UserLogin + @"\" + project.Path;
                var directory = new DirectoryInfo(Server.MapPath(ViewBag.path));
                
                if (!directory.Exists)
                {
                    directory.Create();
                }

                ViewBag.files = directory.GetFiles().ToList();
                ViewBag.subDirectoryList = directory.GetDirectories().ToList();
               
                return View(project);
               
            }
            return RedirectToAction("ProjectsList", "Project");

        }
     

    }
}
