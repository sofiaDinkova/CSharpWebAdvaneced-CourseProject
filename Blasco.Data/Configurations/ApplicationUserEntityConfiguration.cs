namespace Blasco.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasOne(p => p.CustomerType)
                .WithMany(c => c.Customers)
                .HasForeignKey(p => p.CustomerTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
