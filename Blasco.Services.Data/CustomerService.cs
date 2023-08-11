namespace Blasco.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Blasco.Data;
    using Blasco.Data.Models;
    using Blasco.Services.Data.Interfaces;
    using Blasco.Web.ViewModels.Customer;

    public class CustomerService : ICustomerService
    {
        private readonly BlascoDbContext dbContext;
        public CustomerService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public async Task Create(string creatorId, BecomeCustomerFormModel model)
        //{
        //    ApplicationUser newCustomer = new ApplicationUser()
        //    {
        //        //CreatorId = Guid.Parse(creatorId),
        //        CustomerTypeId = model.CustomerType
        //    };

        //    await this.dbContext.Users.AddAsync(newCustomer);
        //    await this.dbContext.SaveChangesAsync();
        //}

        //Do not need it enymore?
        //public async Task<bool> CustomerExistsByCreatorId(string creatorId)
        //{
        //    bool result = await this.dbContext
        //        .Users
        //        .AnyAsync(c => c.Id.ToString() == creatorId);

        //    return result;
        //}

        //Delete
        //public async Task<string?> GetCustomerByUserIdAsync(string userId)
        //{
        //    ApplicationUser? customer = await this.dbContext
        //          .Users
        //          .FirstOrDefaultAsync(c => c.Id.ToString() == userId);

        //    if (customer == null)
        //    {
        //        return null;
        //    }

        //    return customer.Id.ToString();
        //}

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
