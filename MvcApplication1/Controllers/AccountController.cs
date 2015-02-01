using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using WebSecurity = MvcApplication1.Filters.WebSecurity;

namespace MvcApplication1.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            MvcApplication.logger.Info("Open log page at {0}", DateTime.Now);
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
                FormsAuthentication.SetAuthCookie(WebSecurity.UserLogin, WebSecurity.Remeber);
                MvcApplication.logger.Info("Login succesfull at {0} like {1}", DateTime.Now, WebSecurity.UserLogin);
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
            MvcApplication.logger.Info("User {0} logoff at {1}", WebSecurity.UserLogin, DateTime.Now);
            WebSecurity.UserLogin = null;
            WebSecurity.Remeber = false;
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
            MvcApplication.logger.Info("User {0} wan't to change his password at {1}", WebSecurity.UserLogin,
                DateTime.Now);
            //todo якщо 3 раз ввести неправильно свій поточний пароль - розлогінити!!!!
            var user = MvcApplication.RepoContext.UserProfiles.FirstOrDefault(x => x.Login == WebSecurity.UserLogin);
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
                if (!MvcApplication.RepoContext.UserProfiles.Any(x=>x.Mail == _model.UserMail || x.Login == _model.UserLogin))
                {
                    return RedirectToAction("ChooseRole",new {model = _model});
                }
                else
                {
                    _model.IsUserLoginAvilable = !MvcApplication.RepoContext.UserProfiles.Any(x => x.Login == _model.UserLogin);
                    _model.IsUserMailAvilable =  !MvcApplication.RepoContext.UserProfiles.Any(x => x.Mail == _model.UserMail);
                }
            }
            MvcApplication.logger.Warn("Have some errors when register new user at {0}", DateTime.Now);
            return View(_model);
        }
       
        [HttpGet]
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
        public ActionResult ChooseRole(UserProfile model)
        {
            MvcApplication.RepoContext.UserProfiles.Add(model);
            MvcApplication.RepoContext.SaveChanges();
            MvcApplication.logger.Info("Set into DB new user - login => {0}, mail => {1}, password => {2}",
                model.Login, model.Mail, model.Password, model.Role);
            WebSecurity.UserLogin = model.Login;
            WebSecurity.Remeber = false;
            FormsAuthentication.SetAuthCookie(WebSecurity.UserLogin, WebSecurity.Remeber);
            MvcApplication.logger.Info("Set next user as already login {0}", WebSecurity.UserLogin);
            return RedirectToAction("Index", "Home");
        }
    }
}