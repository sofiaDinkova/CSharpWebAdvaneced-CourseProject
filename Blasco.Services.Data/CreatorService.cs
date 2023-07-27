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
            Creator creator = await this.dbContext
                .Users
                .FirstAsync(c => c.Id.ToString() == creatorId);

            return creator.Products.Any();
        }

        public async Task<bool> HasProductWithIdAsync(string productId, string userId)
        {
            Creator? creator = await this.dbContext
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
    }
}
