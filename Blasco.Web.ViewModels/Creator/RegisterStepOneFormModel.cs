namespace Blasco.Web.ViewModels.Creator
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterStepOneFormModel
    {
        [Required]
        public string Role { get; set; } = null!;
    }
}
