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
                .FirstAsync(c=>c.Id.ToString() == creatorId);

            return creator.Products.Any();
        }
    }
}
