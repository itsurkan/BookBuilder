using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.DbModels;
using MvcApplication1.Filters;

namespace MvcApplication1.Controllers
{
    public class BuildController : Controller
    {
        private Entities db = MvcApplication.RepoContext;
        public NLog.Logger Log = MvcApplication.logger;

        public ActionResult Index(int id)
        {
            ViewBag.Message = "Builds Page";
            MvcApplication.logger.Info("Open builds page from {0} at {1}", WebSecurity.UserLogin, DateTime.Now);
            
            Projects project = db.Projects.Find(id);

            if (project != null)
            {
                return View(project);
            }
            return RedirectToAction("ProjectsList", "Project");

        }
    }
}
