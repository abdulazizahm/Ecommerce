using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(20)]
        [Display(Name ="First name")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name ="Last name")]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        public string Photo { get; set; }

        //[customAttribute] for Email uniqueness
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(6)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name ="Confirm password")]
        [Compare("PasswordHash")]
        public string ConfirmPassword { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }


        [Display(Name = "Account Type")]
        public string Role { get; set; }
    }
}
