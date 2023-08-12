namespace Blasco.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Blasco.Data;
    using Blasco.Web.ViewModels.CustomerType;

    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly BlascoDbContext dbContext;
        public CustomerTypeService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CustomerTypeSelectFormModel>> AllCustomerTypesAsync()
        {
            IEnumerable<CustomerTypeSelectFormModel> allCustomerTypes = await this.dbContext
                .CustomerTypes
                .AsNoTracking()
                .Select(c => new CustomerTypeSelectFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCustomerTypes;
        }
    }
}
