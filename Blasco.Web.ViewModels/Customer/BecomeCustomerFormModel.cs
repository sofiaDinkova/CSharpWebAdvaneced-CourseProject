namespace Blasco.Web.ViewModels.Customer
{
    using System.ComponentModel.DataAnnotations;

    public class BecomeCustomerFormModel
    {
        [Required]
        public int CustomerType { get; set; } 
    }
}
