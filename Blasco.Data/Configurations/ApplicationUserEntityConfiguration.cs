using Blasco.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Xml.Linq;

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
            //seed just Admin
            //builder.HasData(this.GenerateUsers());
        }
        private ApplicationUser[] GenerateUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            ICollection<ApplicationUser> creators = new HashSet<ApplicationUser>();

            ApplicationUser creator;

            creator = new ApplicationUser()
            {
                Email = "seededCreator@creator.com",
                PasswordHash = hasher.HashPassword(null, "123456"),
                FirstName = "First",
                LastName = "Customer",
                UserName_Pseudonym = "veryCreativePseudonym",
                Categories = new ProductProjectCategory[]
                {
                    new ProductProjectCategory
                    {
                        Id = 1,
                        Name = "Animation"
                    },
                    new ProductProjectCategory
                    {
                        Id = 5,
                        Name = "Graphic design"
                    }
                }
            };
            creators.Add(creator);

            return creators.ToArray();
        }
    }
}
