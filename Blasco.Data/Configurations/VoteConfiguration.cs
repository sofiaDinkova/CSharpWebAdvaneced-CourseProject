using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blasco.Data.Models;

namespace Blasco.Data.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder
               .Property(p => p.CreatedOn)
               .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(v => v.ApplicationUserWhoVoted)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.ApplicationUserWhoVotedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.ProjectCastOn)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.ProjectCastOnId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
