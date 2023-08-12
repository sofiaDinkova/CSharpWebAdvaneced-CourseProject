namespace Blasco.Data.Configurations
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Blasco.Data.Models;

    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder
               .Property(c => c.CreatedOn)
               .HasDefaultValueSql("GETDATE()");

            builder
               .Property(c => c.EndDate)
               .HasDefaultValueSql("DATEADD(month, +2, GETDATE())");

            builder
                .HasOne(c => c.Category)
                .WithMany(p => p.Challenges)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.CustomerCreatedChallenge)
                .WithMany(u => u.Challenges)
                .HasForeignKey(c => c.CustomerCreatedChallengeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
