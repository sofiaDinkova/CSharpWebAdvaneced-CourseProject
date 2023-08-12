namespace Blasco.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ApplicationUserPPCategoryConfiguration : IEntityTypeConfiguration<ApplicationUserPPCategory>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserPPCategory> builder)
        {
            builder
                .HasKey(ac => new { ac.PPCategoryId, ac.ApplicationUserId });

            builder
                .HasOne(ac => ac.ProductProjectCategory)
                .WithMany(c => c.Creators)
                .HasForeignKey(ac => ac.PPCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ac => ac.ApplicationUser)
                .WithMany(a=>a.PPCategories)
                .HasForeignKey(ac =>ac.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
