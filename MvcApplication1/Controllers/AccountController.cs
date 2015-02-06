using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI.WebControls;
using DotNetOpenAuth.AspNet;
using Microsoft.Ajax.Utilities;
using Microsoft.Web.WebPages.OAuth;
using MvcApplication1.DbModels;
using MvcApplication1.Filters;
using MvcApplication1.Resources;
using WebMatrix.WebData;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (MvcApplication.WebSecurity.ControllerContext == null)
                MvcApplication.WebSecurity.ControllerContext = this.ControllerContext;
            if (MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserLogin"))
                return RedirectToAction("ProjectsList", "Project");
            MvcApplication.logger.Info("Open log page at {0}", DateTime.Now);
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {            
            if (ModelState.IsValid && MvcApplication.WebSecurity.Login(model.UserMail, model.Password, model.RememberMe))
            {
                FormsAuthentication.SetAuthCookie(MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value, model.RememberMe);
                MvcApplication.logger.Info("Login succesfull at {0} like {1}", DateTime.Now, MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value);
                return RedirectToLocal(returnUrl);
            }
            MvcApplication.logger.Warn("Login failed with user mail {0} at {1}", model.UserMail, DateTime.Now);
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
            MvcApplication.logger.Info("User {0} logoff at {1}", MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value, DateTime.Now);
            MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Expires = DateTime.Now.AddDays(-1);
            MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies.Remove("UserLogin");
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            MvcApplication.logger.Info("Open Registration page at {0}", DateTime.Now);
            return View(new RegisterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (!MvcApplication.WebSecurity.CheckUserLogin("/Account/ChangePassword"))
                RedirectToAction("Login", "Account");

            MvcApplication.logger.Info("User {0} wan't to change his password at {1}", MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value,
                DateTime.Now);
            var user = MvcApplication.RepoContext.UserProfiles.FirstOrDefault(x => x.Login == MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value);
            var errorModel = new ChangePasswordModel();
            if (user != null)
            {
                if (model.OldPassword != null)
                    if (user.Password != model.OldPassword)
                        errorModel.IsOldPasswordHasError = true;
                if (model.NewPassword != null)
                    if (model.NewPassword.Length < 6)
                        errorModel.IsNewPasswordHasError = true;
                if (model.ConfirmPassword != null)
                    if (model.NewPassword != model.ConfirmPassword)
                        errorModel.IsConfirmPasswordHasError = true;
                if (!errorModel.IsConfirmPasswordHasError
                    && !errorModel.IsNewPasswordHasError
                    && !errorModel.IsOldPasswordHasError
                    && model.OldPassword != null
                    && model.NewPassword != null
                    && model.ConfirmPassword != null)
                {
                    user.Password = model.NewPassword;
                    MvcApplication.RepoContext.SaveChanges();
                }
                if (errorModel.IsOldPasswordHasError)
                    MvcApplication.WebSecurity.FailCounter++;
                if (MvcApplication.WebSecurity.FailCounter == MvcApplication.WebSecurity.RetryCount)
                {
                    MvcApplication.WebSecurity.FailCounter = 0;
                    MvcApplication.logger.Warn("User enter 3 times wrong password, redirect to logoff and to login after at {0}", DateTime.Now);
                    return RedirectToAction("LogOff");
                }
            }
            else
            {
                MvcApplication.logger.Error("User is empty redirect to logoff and to login after at {0}", DateTime.Now);
                return RedirectToAction("LogOff");
            }
            return RedirectToAction("UserSettings", "Settings", new
            {
                isOldPasswordHasError = errorModel.IsOldPasswordHasError,
                isNewPasswordHasError = errorModel.IsNewPasswordHasError,
                isConfirmPasswordHasError = errorModel.IsConfirmPasswordHasError
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel _model)
        {
            MvcApplication.logger.Info("Try registration at {0}", DateTime.Now);
            if (ModelState.IsValid)
            {
                if (!MvcApplication.RepoContext.UserProfiles.Any(x => x.Mail == _model.UserMail || x.Login == _model.UserLogin))
                {
                    return RedirectToAction("ChooseRole", new { model = _model });
                }
                else
                {
                    _model.IsUserLoginAvilable = !MvcApplication.RepoContext.UserProfiles.Any(x => x.Login == _model.UserLogin);
                    _model.IsUserMailAvilable = !MvcApplication.RepoContext.UserProfiles.Any(x => x.Mail == _model.UserMail);
                }
            }
            MvcApplication.logger.Warn("Have some errors when register new user at {0}", DateTime.Now);
            return View(_model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ChooseRole(RegisterModel model)
        {
            var profileModel = new UserProfile();
            if (model != null)
            {
                profileModel = new UserProfile
                {
                    Login = model.UserLogin,
                    Mail = model.UserMail,
                    Password = model.Password
                };
            }
            return View(profileModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ChooseRole(UserProfile model)
        {
            MvcApplication.RepoContext.UserProfiles.Add(model);
            MvcApplication.RepoContext.SaveChanges();
            MvcApplication.logger.Info("Set into DB new user - login => {0}, mail => {1}, password => {2}",
                model.Login, model.Mail, model.Password, model.Role);
            MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value = model.Login;
            FormsAuthentication.SetAuthCookie(MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value, false);
            MvcApplication.logger.Info("Set next user as already login {0}", MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult View1()
        {
            return View();
        }
    }
}