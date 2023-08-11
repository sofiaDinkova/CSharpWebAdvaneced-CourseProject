namespace Blasco.Services.Data
{
    using Blasco.Data;
    using Blasco.Data.Models;
    using Blasco.Services.Data.Interfaces;
    using Blasco.Web.ViewModels.Creator;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly BlascoDbContext dbContext;

        public UserService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UserViewModel>> AllUsersAsync()
        {
            List<UserViewModel> allUsers = new List<UserViewModel>();

            ICollection<UserViewModel> creators = await this.dbContext
                .Users
                .Where(u => u.Pseudonym != null)
                .Select(u => new UserViewModel
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    Pseudonym = u.Pseudonym,
                    FullName = $"{u.FirstName} {u.LastName}",
                    CustomerType = string.Empty
                })
                .ToListAsync();
            allUsers.AddRange(creators);

            ICollection<UserViewModel> customers = await this.dbContext
                .Users
                .Where(u => u.CustomerTypeId != null)
                .Select(u => new UserViewModel
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    CustomerType = u.CustomerType.Name,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Pseudonym = string.Empty
                })
                .ToListAsync();

            allUsers.AddRange(customers);

            return allUsers;
        }

        public async Task<bool> DidAllreadyVoteForChallengeAsync(string userId, string challengeId)
        {
            bool result = await this.dbContext
                .Votes
                .AnyAsync(c => c.ChallengeId.ToString() == challengeId &&
                               c.ApplicationUserWhoVotedId.ToString()! == userId);

            return result;
        }

        //if not used DELETE
        public async Task<string> GetFullNameByIdAsync(string id)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == id);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        
    }
}
