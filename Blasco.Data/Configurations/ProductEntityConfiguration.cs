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

            //builder
            //    .HasOne(p => p.Customer)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CustomerId)
            //    .OnDelete(DeleteBehavior.Restrict);

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
                CreatorId = Guid.Parse("0C13DBA1-B072-4E26-9CC5-F93EB50ADF00"),
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
                CreatorId = Guid.Parse("635E95CA-66D3-424B-A63B-6C17B36BBB42"),
                City = "London",
                CustomerId = Guid.Parse("650511F1-B82C-4D3B-85F5-D769C096AA97")
            };
            products.Add(product);

            product = new Product()
            {
                Title = "Girl with a sword and dog",
                Description = "High-quality Print of a girl with a sword and dog",
                ImageUrl = "https://global-uploads.webflow.com/5e3ce2ec7f6e53c045fe7cfa/603debbc0b31de538d79fa5e_discovery.png",
                Price = 23,
                CategoryId = 11,
                CreatorId = Guid.Parse("635E95CA-66D3-424B-A63B-6C17B36BBB42"),
                City = "Paris",
            };
            products.Add(product);

            product = new Product()
            {
                Title = "Sunrise",
                Description = "Beautiful sunrise over mountains",
                ImageUrl = "https://reviewed-com-res.cloudinary.com/image/fetch/s--bELGdL_2--/b_white,c_limit,cs_srgb,f_auto,fl_progressive.strip_profile,g_center,q_auto,w_972/https://reviewed-production.s3.amazonaws.com/1655235044230/341DA4D2-A0C7-4E24-AC12-04BD64CDC6E1_1_201_a.jpeg",
                Price = 23,
                CategoryId = 13,
                CreatorId = Guid.Parse("7CD705C4-C50A-45A2-AD5B-4FE7FDF3B009"),
                City = "Madrid",
            };
            products.Add(product);

            product = new Product()
            {
                Title = "Heavy Textured 3d Abstract Art Painting",
                Description = "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...",
                ImageUrl = "https://images.saatchiart.com/saatchi/1883590/art/10134163/9196933-ZIJATGTD-6.jpg",
                Price = 23,
                CategoryId = 7,
                CreatorId = Guid.Parse("7CD705C4-C50A-45A2-AD5B-4FE7FDF3B009"),
                City = "Madrid",
            };
            products.Add(product);



            return products.ToArray();
        }
    }
}
