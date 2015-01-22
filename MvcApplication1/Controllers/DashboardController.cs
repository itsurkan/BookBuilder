using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult DashBoard()
        {
            ViewBag.Message = "DashBoard.";

            return View();
        }
     

    }
}
