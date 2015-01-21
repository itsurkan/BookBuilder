using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public DataClasses1DataContext db =MvcApplication.db;
        
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

            var projects = from s in db.Projects
                           select s;
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

        public ActionResult NewProject()
        {
            ViewBag.Message = "New Project.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]Student student)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Students.Add(student);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (RetryLimitExceededException /* dex */)
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //    }
        //    return View(student);
        //}

        public ActionResult DashBoard()
        {
            ViewBag.Message = "DashBoard.";

            return View();
        }
     
        public ActionResult Configure()
        {
            ViewBag.Message = "Configuration Page.";

            return View();
        }

        public ActionResult Builds()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }

        public ActionResult Review()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }

        public ActionResult Setting()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }

        public ActionResult Editor()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }

    }
}