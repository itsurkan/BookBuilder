using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.DbModels;
using WebMatrix.WebData;
using MvcApplication1;

namespace MvcApplication1.Filters
{
    public static class WebSecurity
    {
        public static string UserLogin { get; set; }
        public static bool Remeber { get; set; }
        private static bool tryAgain = true;

        static WebSecurity()
        {
            UserLogin = null;
        }

        internal static bool Login(string mail, string pass, bool remeber)
        {
            try
            {
                var user = MvcApplication.db.UserProfiles.FirstOrDefault(u => u.Mail == mail && u.Password == pass);
                if (user != null)
                {
                    UserLogin = user.Login;
                    Remeber = remeber;
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
                    MvcApplication.logger.Info("Throw error");
                    throw e;
                }
            }
            return false;
        }

        public static bool CheckUserLogin(string location)
        {
            if (WebSecurity.UserLogin == null)
            {
                MvcApplication.logger.Error("User login == null at {0} at {1}",location, DateTime.Now);
                return false;
            }
            return true;
        }
    }
}