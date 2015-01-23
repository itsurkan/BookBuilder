using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using MvcApplication1.Classes;
using MvcApplication1.DbModels;
using MvcApplication1.Filters;
using MvcApplication1.Resources;
using  PagedList;
using PagedList.Mvc;

namespace MvcApplication1.Controllers
{ 
    public class ProjectController : Controller
    {
        public Entities RepoContext = MvcApplication.db;
        public NLog.Logger Log = MvcApplication.logger;
        public static string PathToFiles = "App_Data/";

        //
        // GET: /Projects/
        [HttpGet]
       
        public ViewResult ProjectsList(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var projects = from s in RepoContext.Projects where s.UserLogin == WebSecurity.UserLogin select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(s => s.Title.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    projects = projects.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    projects = projects.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    projects = projects.OrderByDescending(s => s.Date);
                    break;
                default:  // Name ascending 
                    projects = projects.OrderBy(s => s.Title);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(projects.ToPagedList(pageNumber, pageSize));

        }


        [HttpGet]
        public ActionResult NewProject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewProject([Bind(Include = "Title, Description")]Projects project)
        {
            Log.Info("new project {0}", DateTime.Now);
            project.Date = DateTime.Now;
            project.UserLogin = WebSecurity.UserLogin;
            project.Path = project.Title.Translit();
            try
            {
                if (ModelState.IsValid)
                {
                    RepoContext.Projects.Add(project);
                    RepoContext.SaveChanges();

                    Log.Info("new project success {0}", DateTime.Now);
                    return RedirectToAction("ProjectsList");
                }
            }
            catch (Exception /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", Messages.Unable_to_save_changes);

                Log.Info("new project error {0}", DateTime.Now);
            }
            return View(project);
        }

        public ActionResult Setting()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }
  
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Log.Info("Edit title page {0}", DateTime.Now);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var project = RepoContext.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            Log.Info("Edit title page exit {0}", DateTime.Now);

            return View(project);

        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            MvcApplication.logger.Info("Edit title page click {0}", DateTime.Now);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var projecttoUpdate = RepoContext.Projects.Find(id);
            if (TryUpdateModel(projecttoUpdate, "",
               new string[] { "Title", "Description" }))
            {
                try
                {
                    MvcApplication.logger.Info("Edit title page update action {0}", DateTime.Now);
                    RepoContext.Entry(projecttoUpdate).State = EntityState.Modified;
                    RepoContext.SaveChanges();
                    return RedirectToAction("ProjectsList");
                }
                catch (Exception e)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    MvcApplication.logger.Info("Edit title page error {0}", DateTime.Now);

                }

                MvcApplication.logger.Info("Edit title page end{0}", DateTime.Now);

            }
             return View(projecttoUpdate);
        }

        [HttpGet]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Projects project = RepoContext.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                MvcApplication.logger.Info("Delete project {0}", DateTime.Now);

                Projects project= RepoContext.Projects.Find(id);
                RepoContext.Projects.Remove(project);
                RepoContext.SaveChanges();
            }
            catch (Exception/* dex */)
            {
                MvcApplication.logger.Info("Delete project {0} exception {1}", id, DateTime.Now);

                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Setting", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("ProjectsList");
        }
        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    RepoContext.Dispose();
            //}
            //base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult ArchiveProject(object value)
        {
            return RedirectToAction("ProjectsList");
        }
    }
}