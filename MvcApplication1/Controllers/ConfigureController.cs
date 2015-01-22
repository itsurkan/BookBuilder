using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ConfigureController : Controller
    {
        //
        // GET: /Configure/

        public ActionResult Configure()
        {
            ViewBag.Message = "Configuration Page.";

            return View();
        }

    }
}
