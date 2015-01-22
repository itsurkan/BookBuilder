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
using  PagedList;
using PagedList.Mvc;

namespace MvcApplication1.Controllers
{ 
    public class ProjectController : Controller
    {
        public DataClasses1DataContext RepoContext = MvcApplication.db;

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

            var projects = from s in RepoContext.Projects where s.UserLogin == "root" select s;
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

        [HttpPost, ActionName("NewProject")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Description")]Projects projects)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        db.Students.Add(student);
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //}
            //catch (RetryLimitExceededException /* dex */)
            //{
            //    //Log the error (uncomment dex variable name and add a line here to write a log.
            //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            //}
            return View();
        }

        public ActionResult Setting()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            MvcApplication.logger.Info("Edit title page {0}", DateTime.Now);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = (from p in RepoContext.Projects where p.Id == id select p).First();
            MvcApplication.logger.Info("Edit title page exit {0}", DateTime.Now);
          
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
            var projecttoUpdate = (from p in RepoContext.Projects where p.Id == id select p).First();
            if (TryUpdateModel(projecttoUpdate, "",
               new string[] { "Title", "Descriprion" }))
            {
                try
                {
                    MvcApplication.logger.Info("Edit title page update action {0}", DateTime.Now);

                    RepoContext.SubmitChanges();

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
            return View("EditProperties",projecttoUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            MvcApplication.logger.Info("Try to gelete {0}", DateTime.Now.TimeOfDay);
          
            //try
            //{
            //    Projects project =  (from p in RepoContext.Projects where p.Id == id select p).First();
            //    //db.Projects.Remove();
            //    RepoContext.SubmitChanges();
            //}
            //catch (Exception/* dex */)
            //{
            //    MvcApplication.logger.Info("Try to gelete exception {0}", DateTime.Now.TimeOfDay);
            //    //Log the error (uncomment dex variable name and add a line here to write a log.
            //    return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            //}
            return RedirectToAction("ProjectsList", "Project");
        }
    }
}