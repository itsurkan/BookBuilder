using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.DbModels;
using MvcApplication1.Filters;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (!WebSecurity.CheckUserLogin("/ProjectsList/Project"))
                RedirectToAction("Login","Account");
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";


            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Sort by Created", Value = "0" });
            li.Add(new SelectListItem { Text = "Sort by Name", Value = "1" });
            li.Add(new SelectListItem { Text = "Sort by Updated", Value = "2" });

            ViewData["Sort"] = li;
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AccountSettings()
        {
            ViewBag.Message = "Configuration Page.";

            return View();
        }
    }
}
