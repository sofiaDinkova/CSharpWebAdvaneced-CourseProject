﻿using System.ComponentModel.DataAnnotations;
using static Blasco.Common.EntityValidationConstants.ApplicationUser;
using System.Xml.Linq;

namespace Blasco.Web.ViewModels.Creator
{
    public class RegisterFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PassMaxLenght, MinimumLength = PassMinLenght, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLenght, MinimumLength = FirstNameMinLenght)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLenght, MinimumLength = LastNameMinLenght)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PseudonymMaxLenght, MinimumLength =PseudonymMinLenght)]
        public string UserName { get; set; } = null!;
    }
}
