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
            MvcApplication.logger.Info("Open account settings for {0} at {1}", WebSecurity.UserLogin, DateTime.Now);
            ViewBag.IsOldPasswordHasError = isOldPasswordHasError ?? false;
            ViewBag.IsNewPasswordHasError = isNewPasswordHasError ?? false;
            ViewBag.IsConfirmPasswordHasError = isConfirmPasswordHasError ?? false;
            return View(MvcApplication.RepoContext
                .UserProfiles.FirstOrDefault(x => x.Login == WebSecurity.UserLogin));
        }
    }
}
   //@*<div class="col-md-4">
   //         <div class="box down20 ">
   //             <div class="box-top">
   //                 <h3>Change Password</h3>
   //             </div>
   //             <div class="box-inner">
   //                    <div style="margin:0;padding:0;display:inline"><input name="utf8" type="hidden" value="✓"><input name="_method" type="hidden" value="put"><input name="authenticity_token" type="hidden" value="gvLC6PT08/bCOKAABwfCxvQaO5gbvqL1xBF8T7SHpG0="></div>
                        
   //                         <label for="old-password">Old password</label>
   //                         <input id="old-password" type="password" name="current_password" style="height:100%;">
   //                         <p>Passwords must be at least 8 characters.</p>
   //                         <label for="new-password">New password</label>
   //                         <input id="new-password" type="password" name="password" style="height:100%;">
   //                         <label for="new-password-confirm">Confirm new password</label>
   //                         <input id="new-password-confirm" type="password" name="password_confirmation" style="height:100%;">
   //                     <input type="submit" class="btn btn-success down10" value="Change Password">
                  
   //             </div>
   //         </div>
   //     </div>*@