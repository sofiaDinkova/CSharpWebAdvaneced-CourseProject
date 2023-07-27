namespace Blasco.Web.ViewModels.Product
{
    public class ProductDetailsViewModel : ProductAllViewModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string CreatorId { get; set; } = null!;

        public string CreatorEmail { get; set; } = null!;

        public string CreatorPseudonym { get; set;} = null!;

    }
}
