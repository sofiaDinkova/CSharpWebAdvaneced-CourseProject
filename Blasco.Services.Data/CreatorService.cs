using Blasco.Data;
using Blasco.Data.Models;
using Blasco.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blasco.Services.Data
{
    public class CreatorService : ICreatorService
    {
        private readonly BlascoDbContext dbContext;

        public CreatorService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreatorHasProductsAsync(string creatorId)
        {
            ApplicationUser creator = await this.dbContext
                .Users
                .FirstAsync(c => c.Id.ToString() == creatorId);

            return creator.Products.Any();
        }
                
        public async Task<bool> HasProductWithIdAsync(string productId, string userId)
        {
            ApplicationUser? creator = await this.dbContext
                .Users
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id.ToString() == userId);

            if (creator == null)
            {
                return false;
            }

            productId = productId.ToLower();
            return creator.Products.Any(p => p.Id.ToString() == productId);
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? creator = await this.dbContext
                .Users
                .FirstOrDefaultAsync(c=>c.Email == email);

            if (creator == null)
            {
                return string.Empty;
            }

            return $"{creator.FirstName} {creator.LastName}";
        }

        public async Task<string> GetCreatorPseudonymByIdAsync(string email)
        {
            ApplicationUser? creator = await this.dbContext
                .Users
                .FirstOrDefaultAsync(c => c.Email == email);

            if (creator == null)
            {
                return string.Empty;
            }

            return creator.UserName;
        }
    }
}
