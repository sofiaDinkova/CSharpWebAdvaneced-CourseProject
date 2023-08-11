using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Web.ViewModels.Project
{
    public class ProjectParticipateViewModel : ProjectAllViewModel
    {
        public string ChallengeId { get; set; } = null!;

        public string ChallengeName { get; set; } = null!;

        public string ChallengeCategory { get; set;} = null!;
    }
}
