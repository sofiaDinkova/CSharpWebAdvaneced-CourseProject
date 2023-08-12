namespace Blasco.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    public interface IVoteService
    {
        Task CreateVote(string userId, string projectId, string challengeId);
    }
}
