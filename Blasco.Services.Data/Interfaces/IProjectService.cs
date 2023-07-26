namespace Blasco.Services.Data.Interfaces
{
   using Web.ViewModels.Home;

    public interface IProjectService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeProjectAsync();

        
    }
}
