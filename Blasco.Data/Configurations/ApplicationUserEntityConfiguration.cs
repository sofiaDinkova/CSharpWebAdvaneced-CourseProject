using Blasco.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Xml.Linq;
using Blasco.Data.Configurations.Seed;

namespace Blasco.Data.Configurations
{
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
