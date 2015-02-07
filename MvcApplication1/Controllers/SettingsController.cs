using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Filters;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        [HttpGet]
        public ActionResult UserSettings(bool? isOldPasswordHasError, bool? isNewPasswordHasError, bool? isConfirmPasswordHasError)
        {
            if (!MvcApplication.WebSecurity.CheckUserLogin("/Settings/UserSettings"))
                RedirectToAction("Login", "Account");
            MvcApplication.logger.Info("Open account settings for {0} at {1}", MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value, DateTime.Now);
            ViewBag.IsOldPasswordHasError = isOldPasswordHasError ?? false;
            ViewBag.IsNewPasswordHasError = isNewPasswordHasError ?? false;
            ViewBag.IsConfirmPasswordHasError = isConfirmPasswordHasError ?? false;
            var userName =  MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value;
            return View(MvcApplication.RepoContext
                .UserProfiles.FirstOrDefault(x => x.Login == userName));
        }
    }
}