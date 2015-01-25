using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DotNetOpenAuth.Configuration;
using MvcApplication1.Resources;

namespace MvcApplication1.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(50000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "Password_Length", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = @"New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Confirm password")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RegisterModel_UserPass_Compare")]
        public string ConfirmPassword { get; set; }

        public readonly string OldPasswordError = Messages.Account_ConfirmCurrentPassword_InCorrect;
        public readonly string NewPasswordError = Messages.Password_Length;
        public readonly string ConfirmPasswordError = Messages.RegisterModel_UserPass_Compare;

        public bool IsOldPasswordHasError = false;
        public bool IsNewPasswordHasError = false;
        public bool IsConfirmPasswordHasError = false;
    }

}