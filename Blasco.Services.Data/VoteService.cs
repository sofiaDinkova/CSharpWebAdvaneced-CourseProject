﻿using Blasco.Data;
using Blasco.Data.Models;
using Blasco.Services.Data.Interfaces;

namespace Blasco.Services.Data
{
    public class VoteService : IVoteService
    {
        private readonly BlascoDbContext dbContext;

        public VoteService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateVote(string userId, string projectId, string challengeId)
        {
            Vote vote = new Vote
            {
                ProjectCastOnId = Guid.Parse(projectId),
                ChallengeId = Guid.Parse(challengeId),
                ApplicationUserWhoVotedId = Guid.Parse(userId)

            };

            await this.dbContext.Votes.AddAsync(vote);
            await this.dbContext.SaveChangesAsync();
        }
    }
}