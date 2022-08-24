using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteAPI.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation do not match")]
        public string ComfirmPassword { get; set; }
    }
}
