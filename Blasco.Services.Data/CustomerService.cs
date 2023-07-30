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
            ApplicationUser newCustomer = new ApplicationUser()
            {
                //CreatorId = Guid.Parse(creatorId),
                CustomerType = (CustomerType)Enum.Parse(typeof(CustomerType), model.CustomerType)
            };

            await this.dbContext.Users.AddAsync(newCustomer);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> CustomerExistsByCreatorId(string creatorId)
        {
            bool result = await this.dbContext
                .Users
                .AnyAsync(c => c.Id.ToString() == creatorId);

            return result;
        }

        public async Task<string?> GetCustomerByUserIdAsync(string userId)
        {
            ApplicationUser? customer = await this.dbContext
                  .Users
                  .FirstOrDefaultAsync(c => c.Id.ToString() == userId);

            if (customer == null)
            {
                return null;
            }

            return customer.Id.ToString();
        }

        public async Task<bool> HasProductWithIdAsync(string productId, string userId)
        {
            ApplicationUser? customer = await this.dbContext
                .Users
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id.ToString() == userId);

            if (customer == null)
            {
                return false;
            }

            productId = productId.ToLower();
            return customer.Products.Any(p => p.Id.ToString() == productId);
        }
    }
}
