using Blasco.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Data.Configurations
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasData(this.GenerateCategories());
        }
        private CustomerType[] GenerateCategories()
        {
            ICollection<CustomerType> categories = new HashSet<CustomerType>();

            CustomerType category;

            category = new CustomerType()
            {
                Id = 1,
                Name = "Private Customer"
            };
            categories.Add(category);

            category = new CustomerType()
            {
                Id = 2,
                Name = "Freelancer"
            };
            categories.Add(category);

            category = new CustomerType()
            {
                Id = 3,
                Name = "Buisness"
            };
            categories.Add(category);

            return categories.ToArray();

        }
    }
}
