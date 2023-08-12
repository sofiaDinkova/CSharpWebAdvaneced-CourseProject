namespace Blasco.Services.Data.Interfaces
{
    using Web.ViewModels.CustomerType;

    public interface ICustomerTypeService
    {
        Task<IEnumerable<CustomerTypeSelectFormModel>> AllCustomerTypesAsync();
    }
}
