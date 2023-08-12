namespace Blasco.Web.ViewModels.Image
{
    public class ImageDeleteFormModel
    {
        public string? Id { get; set; }
        public byte[]? ExistingImage { get; set; } 
        public bool ToBeDeleted { get; set; }
    }
}
