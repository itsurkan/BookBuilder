using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class EditorController : Controller
    {
        //
        // GET: /Editor/

        public ActionResult Editor()
        {
            ViewBag.Message = "Builds Page.";

            return View();
        }


    }
}
