namespace Blasco.Data.Models
{
    using System;

    public class Vote
    {
        public Guid Id { get; set; }

        public Guid ProjectCastOnId { get; set; }
        public Project ProjectCastOn { get; set; } = null!;

        public Guid ChallengeId { get; set; }

        public Challenge Challenge { get; set; } = null!;

        public Guid ApplicationUserWhoVotedId { get; set; }

        public ApplicationUser ApplicationUserWhoVoted { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
    }
}
