using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Filters;

namespace MvcApplication1.Controllers
{
    public class SettingsController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult UserSettings()
        {
            return View(MvcApplication.RepoContext.UserProfiles.FirstOrDefault(x=>x.Login == WebSecurity.UserLogin));
        }

    }
}
