using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using DotNetOpenAuth.AspNet;
using Microsoft.Ajax.Utilities;
using Microsoft.Web.WebPages.OAuth;
using MvcApplication1.DbModels;
using MvcApplication1.Filters;
using MvcApplication1.Resources;
using WebMatrix.WebData;
using MvcApplication1.Models;

namespace MvcApplication1.Filters
{
    public class WebSecurityController : Controller
    {
        private bool tryAgain;
        public readonly int RetryCount = 3;
        public int FailCounter { get; set; }

        public WebSecurityController()
        {
            tryAgain = true;
        }

        public bool Login(string mail, string pass, bool remeber)
        {
            try
            {
                var user = MvcApplication.RepoContext.UserProfiles.FirstOrDefault(u => u.Mail == mail && u.Password == pass);
                if (user != null)
                {
                    if (MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserLogin"))
                    {
                        MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value = user.Login;
                        if(remeber)
                            MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Expires = DateTime.Now.AddDays(3000);

                    }
                    else
                    {
                        MvcApplication.WebSecurity.ControllerContext.HttpContext.Response.Cookies.Add(new HttpCookie("UserLogin") { Value = user.Login });
                        if (remeber)
                            MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Expires = DateTime.Now.AddDays(3000);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                if (tryAgain)
                {

                    tryAgain = false;
                    Login(mail, pass, remeber);
                    MvcApplication.logger.Info(e.Message);
                }
                else
                {
                    tryAgain = true;
                    MvcApplication.logger.Error("Throw error");
                    throw e;
                }                
            }
            return false;
        }



        /// <summary>
        /// If we need one more time check user call this static method to see if user avilable now
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool CheckUserLogin(string location)
        {
            if (MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("UserLogin"))
            {
                if (MvcApplication.WebSecurity.ControllerContext.HttpContext.Request.Cookies["UserLogin"].Value == null)
                {
                    MvcApplication.logger.Error("User login == null at {0} at {1}", location, DateTime.Now);
                    return false;
                }
                return true;
            }
            return false;

        }
    }
}