namespace Blasco.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Blasco.Data.Models;

    public class CreatorEntityConfiguration : IEntityTypeConfiguration<Creator>
    {
        public void Configure(EntityTypeBuilder<Creator> builder)
        {
            builder.Property(c => c.FirstName)
                .HasDefaultValue("Test");

            builder.Property(c => c.LastName)
                .HasDefaultValue("Testov");
        }
    }
}
