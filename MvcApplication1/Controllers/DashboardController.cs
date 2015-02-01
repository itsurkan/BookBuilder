using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.DbModels;
using MvcApplication1.Filters;
using PagedList;
using PagedList.Mvc;

namespace MvcApplication1.Controllers
{
    public class DashboardController : Controller
    {
        public readonly Entities db = MvcApplication.RepoContext;
        public NLog.Logger Log = MvcApplication.logger;
        //
        // GET: /Dashboard/


        [HttpGet]
        public ActionResult Index(int id)
        {
            ViewBag.Message = "DashBoard";
            Log.Info("Dashboard fid project by id:{0}", id);

            Projects project = db.Projects.Find(id);
            ViewBag.CurrentProject = project.Id;

            if (ModelState.IsValid)
            {
                MvcApplication.logger.Info("Open dashboard from {0} at {1} with title = {2}", 
                    WebSecurity.UserLogin, DateTime.Now, project.Title);

                ViewBag.path = @"~\App_Data\" + project.UserLogin + @"\" + project.Path;
                var directory = new DirectoryInfo(Server.MapPath(ViewBag.path));

                if (!directory.Exists)
                    directory.Create();

                ViewBag.subDirectoryList = directory.GetDirectories().ToList();

                var docs = from s in MvcApplication.RepoContext.Documents
                           where s.Project == id select s;
         
                var tuple = new Tuple<Projects, IQueryable<Document>>(project, docs);


                return View(tuple);
            }
            return RedirectToAction("ProjectsList", "Project");
        }



        [HttpPost]
        public ActionResult AddFile()
        {
            // для додвання файлу
            // перевірка на наявність файлу з такою ж назвою


            //var files = directory.GetFiles().ToList();
            //foreach (var file in files)
            //{
            //    docs.Add(new Document()
            //    {
            //        Name = file.Name,
            //        Path = project.Path,
            //        IsInRecycle = "t",
            //        Date = DateTime.Now,
            //        Project = project.Id,
            //        Description = "new file created"
            //    });
            //}
            //foreach (var doc in docs)
            //{
            //    db.Documents.Add(doc);
            //}
            return View();
        }


        public ActionResult Index2(int id, string currentFilter, string searchString, int? page)
        {
            ViewBag.Message = "DashBoard";
            Log.Info("Dashboard fid project by id:{0}", id);

            Projects project = db.Projects.Find(id);
            ViewBag.CurrentProject = project.Id;

            if (ModelState.IsValid)
            {
                MvcApplication.logger.Info("Open dashboard from {0} at {1} with title = {2}",
                    WebSecurity.UserLogin, DateTime.Now, project.Title);

                ViewBag.path = @"~\App_Data\" + project.UserLogin + @"\" + project.Path;
                var directory = new DirectoryInfo(Server.MapPath(ViewBag.path));

                if (!directory.Exists)
                    directory.Create();

                ViewBag.subDirectoryList = directory.GetDirectories().ToList();

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                var docs = from s in MvcApplication.RepoContext.Documents
                           where s.Project == id
                           select s;

                // todo доробити пошук
                if (!String.IsNullOrEmpty(searchString))
                {
                    docs = docs.Where(d => d.Name.Contains(searchString));

                }
                docs = docs.OrderBy(d => d.Name);

                var pageSize = 5;
                var pageNumber = (page ?? 1);
                var tuple = new Tuple<Projects, IPagedList<Document>>(project, docs.ToPagedList(pageSize, pageNumber));


                return View(tuple);
            }
            return RedirectToAction("ProjectsList", "Project");
        }

    }
}
