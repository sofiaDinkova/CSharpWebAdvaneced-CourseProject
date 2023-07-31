using Blasco.Data.Models;
using Blasco.Web.ViewModels.Product;
using Blasco.Web.ViewModels.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Services.Data.Models.Project
{
    public class AllProjectsChallengeModel
    {
        public AllProjectsChallengeModel()
        {
            this.Projects = new HashSet<ProjectChallegeViewModel>();
        }
        public Challenge Challenge { get; set; } = null!;

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectChallegeViewModel> Projects{ get; set; }
    }
}
