using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using MvcApplication1.Resources;

namespace MvcApplication1.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = @"User e-mail")]
        [StringLength(50,ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RegisterModel_UserMail_Length")]
        public string UserMail { get; set; }

        [Required]
        [StringLength(50000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Password_Length", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = @"Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Confirm password")]
        [Compare("Password", ErrorMessageResourceType = typeof(Messages),ErrorMessageResourceName = "RegisterModel_UserPass_Compare")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = @"User Login")]
        [StringLength(30, ErrorMessageResourceType = typeof(Messages),ErrorMessageResourceName = "RegisterModel_UserLogin_Length", MinimumLength = 6)]
        public string UserLogin { get; set; }

        

    }
}