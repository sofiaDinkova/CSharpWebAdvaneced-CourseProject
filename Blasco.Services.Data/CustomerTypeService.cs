using Blasco.Data;
using Blasco.Services.Data.Interfaces;
using Blasco.Web.ViewModels.CustomerType;
using Blasco.Web.ViewModels.ProductProjectCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Services.Data
{
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
