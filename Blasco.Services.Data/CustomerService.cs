namespace Blasco.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Blasco.Data;

    public class CustomerService : ICustomerService
    {
        private readonly BlascoDbContext dbContext;
        public CustomerService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> HasProductWithIdAsync(string productId, string userId)
        {
            bool result = await this.dbContext
                .Products
                .Where(p => p.Id.ToString() == productId)
                .AnyAsync(p=>p.CustomerId.ToString()==userId);

            return result;
        }
    }
}
