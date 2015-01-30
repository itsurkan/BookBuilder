using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    [Authorize]
    public class EditorController : Controller
    {
        public ActionResult Index()
        {
            MvcApplication.logger.Info("Enter to editor at {0}",DateTime.Now);
            return View();
        }


    }
}
