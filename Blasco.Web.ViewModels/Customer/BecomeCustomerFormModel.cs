namespace Blasco.Web.ViewModels.Customer
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Customer;

    public class BecomeCustomerFormModel
    {
        [Required]
        public string CustomerType { get; set; } = null!;
    }
}
