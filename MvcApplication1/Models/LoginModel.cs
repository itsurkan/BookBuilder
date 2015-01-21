using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = @"Email")]
        public string UserMail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Password")]
        public string Password { get; set; }

        [Display(Name = @"Remember me?")]
        public bool RememberMe { get; set; }
    }
}