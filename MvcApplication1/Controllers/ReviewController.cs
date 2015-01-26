using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ReviewController : Controller
    {
        //
        // GET: /Review/


        public ActionResult Review()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }

    }
}
