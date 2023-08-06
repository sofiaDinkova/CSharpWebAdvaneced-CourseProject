using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Data.Models
{
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
