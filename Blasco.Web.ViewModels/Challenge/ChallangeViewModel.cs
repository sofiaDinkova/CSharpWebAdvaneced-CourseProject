using Blasco.Web.ViewModels.Project;
using Blasco.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Web.ViewModels.Challenge
{
    public class ChallangeViewModel
    {
        public ChallangeViewModel()
        {
            this.Projects = new HashSet<ProjectChallegeViewModel>();
        }
        //public Challenge Challenge { get; set; }

        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectChallegeViewModel> Projects { get; set; }
    }
}
