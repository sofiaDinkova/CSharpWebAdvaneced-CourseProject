
namespace Blasco.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ProjectProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductProjectCategory>
    {
        public void Configure(EntityTypeBuilder<ProductProjectCategory> builder)
        {
          //builder.HasData(this.GenerateCategories());
        }

        private ProductProjectCategory[] GenerateCategories()
        {
            ICollection<ProductProjectCategory> catecories = new HashSet<ProductProjectCategory>();

            ProductProjectCategory category;
            category = new ProductProjectCategory()
            {
                Id = 1,
                Name = "Animation"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 2,
                Name = "Architectural plan"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 3,
                Name = "Furniture"
            };
            catecories.Add(category);
            category = new ProductProjectCategory()
            {
                Id = 4,
                Name = "Glass sculpture"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 5,
                Name = "Graphic design"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 6,
                Name = "Illustration"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 7,
                Name = "Interior design"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 8,
                Name = "Metal designs"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 9,
                Name = "Painting"
            };
            catecories.Add(category);
            category = new ProductProjectCategory()
            {
                Id = 10,
                Name = "Photograph"
            };
            catecories.Add(category);
            category = new ProductProjectCategory()
            {
                Id = 11,
                Name = "Print"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 12,
                Name = "Sculpture"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 13,
                Name = "Tapestry"
            };
            catecories.Add(category);

            category = new ProductProjectCategory()
            {
                Id = 14,
                Name = "Video"
            };
            catecories.Add(category);

            return catecories.ToArray();

        }
    }
    
}
