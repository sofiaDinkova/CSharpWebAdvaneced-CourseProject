namespace Blasco.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Creator)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Customer)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateProducts());
        }
        private Product[] GenerateProducts()
        {
            ICollection<Product> products = new HashSet<Product>();

            Product product;

            product = new Product()
            {
                Title = "Bees",
                Description = "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.",
                ImageUrl = "https://image.geo.de/32808766/t/vQ/v5/w1440/r1.5/-/--karine-aigner--1---wildlife-photographer-of-the-year.jpg",
                Price = 15,
                CategoryId = 10,
                CreatorId = Guid.Parse("345DE848-8E19-41A4-944D-36C1B4D24B78"),
                City = "Buenos Aires"
            };
            products.Add(product);

            product = new Product()
            {
                Title = "Horse",
                Description = "Taking her art from life and nature, Helena breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature. Often she uses her experience as a graphic designer to create works with a digital starting point using flat plains that are then assembled into a 3d structure.",
                ImageUrl = "https://artpark.com.au/wp-content/uploads/2022/12/Tosca-60x52x15cm-600x600.jpg",
                Price = 17,
                CategoryId = 12,
                CreatorId = Guid.Parse("345DE848-8E19-41A4-944D-36C1B4D24B78"),
                City = "London",
                CustomerId = Guid.Parse("C99C215F-1621-4874-99B4-14FD0C1EAABE")
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}
