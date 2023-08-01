using Blasco.Web.ViewModels.Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Web.ViewModels.Challenge
{
    public class AllChallengesModel
    {
        public AllChallengesModel()
        {
            this.Challenges = new HashSet<ChallangeAllViewModel>();
        }
        public int TotalChallengesCount { get; set; }

        public IEnumerable<ChallangeAllViewModel> Challenges { get; set; }
    }
}
