using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Ajax.Utilities;
using Microsoft.Web.WebPages.OAuth;
using MvcApplication1.DbModels;
using MvcApplication1.Filters;
using MvcApplication1.Resources;
using WebMatrix.WebData;
using MvcApplication1.Models;
using WebSecurity = MvcApplication1.Filters.WebSecurity;

namespace MvcApplication1.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            MvcApplication.logger.Info("Open log page at {0}",DateTime.Now);
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserMail, model.Password, model.RememberMe))
            {
                FormsAuthentication.SetAuthCookie(WebSecurity.UserLogin,WebSecurity.Remeber);
                return RedirectToLocal(returnUrl);
            }
            ModelState.AddModelError("", Messages.Account_Login_InCorrectModel);
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                //changed
                return RedirectToAction("ProjectsList", "Project");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            MvcApplication.logger.Info("User {0} logoff at {1}",WebSecurity.UserLogin,DateTime.Now);
            WebSecurity.UserLogin = null;
            WebSecurity.Remeber = false;
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            MvcApplication.logger.Info("Open Registration page at {0}", DateTime.Now);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            MvcApplication.logger.Info("Try registration at {0}",DateTime.Now);
            if (ModelState.IsValid)
            {
                MvcApplication.db.UserProfiles.InsertAllOnSubmit(new UserProfile[]
                {
                    new UserProfile
                    {
                        Login = model.UserLogin,
                        Mail = model.UserMail,
                        Password = model.Password,
                        Role = 5
                    }
                });
                MvcApplication.db.SubmitChanges();
                MvcApplication.logger.Info("Set into DB new user - login => {0}, mail => {1}, password => {2}",
                    model.UserLogin,model.UserMail, model.Password);
                WebSecurity.UserLogin = model.UserLogin;
                WebSecurity.Remeber = false;
                FormsAuthentication.SetAuthCookie(WebSecurity.UserLogin,WebSecurity.Remeber);
                MvcApplication.logger.Info("Set next user as already login {0}", WebSecurity.UserLogin);
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
