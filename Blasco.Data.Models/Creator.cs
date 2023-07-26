namespace Blasco.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class Creator : IdentityUser<Guid>
    {
        public Creator()
        {
            this.Id = Guid.NewGuid();

            this.Products = new HashSet<Product>();
            this.Projects = new HashSet<Project>();
        }
        public ICollection<Project> Projects { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
