using Microsoft.AspNetCore.Identity;
using Blasco.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blasco.Data.Configurations.Seed
{
    public class GenerateUsers
    {
        private readonly BlascoDbContext dbContext;

        public GenerateUsers(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApplicationUser[]> GenerateCreator()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            ICollection<ApplicationUser> creators = new HashSet<ApplicationUser>();

            ApplicationUser creator;

            ProductProjectCategory[] categories = await this.dbContext.ProductProjectCategories
                    .Where(c => c.Id == 1 || c.Id == 5)
                    .Select(c=> new ProductProjectCategory
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToArrayAsync();

            creator = new ApplicationUser()
            {
                Email = "firstSeededCreator@creator.com",
                PasswordHash = hasher.HashPassword(null, "123456"),
                FirstName = "First",
                LastName = "Creatorr",
                Pseudonym = "veryCreativePseudonym",
                //Categories = categories
            };
            creators.Add(creator);

            return creators.ToArray();
        }
    }
}
