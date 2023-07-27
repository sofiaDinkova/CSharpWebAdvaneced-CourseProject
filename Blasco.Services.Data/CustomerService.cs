namespace Blasco.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Blasco.Data;
    using Blasco.Data.Models;
    using Blasco.Data.Models.Enums;
    using Blasco.Services.Data.Interfaces;
    using Blasco.Web.ViewModels.Customer;

    public class CustomerService : ICustomerService
    {
        private readonly BlascoDbContext dbContext;
        public CustomerService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(string creatorId, BecomeCustomerFormModel model)
        {
            Customer newCustomer = new Customer()
            {
                CreatorId = Guid.Parse(creatorId),
                CustomerType = (CustomerType)Enum.Parse(typeof(CustomerType), model.CustomerType)
            };

            await this.dbContext.Customers.AddAsync(newCustomer);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> CustomerExistsByCreatorId(string creatorId)
        {
            bool result = await this.dbContext
                .Customers
                .AnyAsync(c => c.CreatorId.ToString() == creatorId);

            return result;
        }

        public async Task<string?> GetCustomerByUserIdAsync(string userId)
        {
            Customer? customer = await this.dbContext
                  .Customers
                  .FirstOrDefaultAsync(c => c.CreatorId.ToString() == userId);

            if (customer == null)
            {
                return null;
            }

            return customer.Id.ToString();
        }

        public async Task<bool> HasProductWithIdAsync(string productId, string userId)
        {
            Customer? customer = await this.dbContext
                .Customers
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.CreatorId.ToString() == userId);

            if (customer == null)
            {
                return false;
            }

            productId = productId.ToLower();
            return customer.Products.Any(p => p.Id.ToString() == productId);
        }
    }
}
