using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.UserModel
{
    public class UserRegistration
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]{2,15}$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]{2,15}$", ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{1,}([.]?[-]?[+]?[a-zA-Z0-9]{1,})?[@]{1}[a-zA-Z0-9]{1,}[.]{1}[a-z]{2,3}([.]?[a-z]{2})?$", ErrorMessage = "Invalid Email Id")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*[@#$&*_+-]{1}[a-zA-Z0-9]*$", ErrorMessage = "Invalid Password type")]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
