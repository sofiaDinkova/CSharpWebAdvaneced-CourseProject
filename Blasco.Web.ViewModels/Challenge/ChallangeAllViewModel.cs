using Blasco.Web.ViewModels.Project;
using Blasco.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static Blasco.Common.EntityValidationConstants.Challenge;

namespace Blasco.Web.ViewModels.Challenge
{
    public class ChallangeAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string PriceToWin { get; set; } = null!;

    }
}
