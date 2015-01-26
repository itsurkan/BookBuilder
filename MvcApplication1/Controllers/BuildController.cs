using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class BuildController : Controller
    {
        //
        // GET: /Build/

        public ActionResult Builds()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }
    }
}
