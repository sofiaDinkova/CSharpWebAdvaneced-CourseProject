namespace Blasco.Web.ViewModels.Customer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomerType;

    using static Blasco.Common.EntityValidationConstants.ApplicationUser;

    public class RegisterCustomerStepTwoFormModel
    {
        public RegisterCustomerStepTwoFormModel()
        {
            this.CustomerTypes = new HashSet<CustomerTypeSelectFormModel>();
        }

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

        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }
        public IEnumerable<CustomerTypeSelectFormModel> CustomerTypes { get; set; } = null!;

    }
}
