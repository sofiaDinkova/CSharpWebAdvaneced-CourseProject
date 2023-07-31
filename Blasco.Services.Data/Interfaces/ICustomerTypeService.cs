using Blasco.Web.ViewModels.CustomerType;
using Blasco.Web.ViewModels.ProductProjectCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Services.Data.Interfaces
{
    public interface ICustomerTypeService
    {
        Task<IEnumerable<CustomerTypeSelectFormModel>> AllCustomerTypesAsync();
    }
}
