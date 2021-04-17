using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAudiomak.Models
{
    public class RegisterViewModel
    {


        [Required]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "رمزعبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "تکرار رمزعبور")]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
    public class LoginViewModel
    {

        [/*PersianRequired,*/ Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required, Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

    }
}
