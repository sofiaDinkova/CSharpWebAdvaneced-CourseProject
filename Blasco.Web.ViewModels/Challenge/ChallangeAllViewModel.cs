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
        public string Id { get; set; } 

        public string Title { get; set; } 

        public string Description { get; set; } 

        public string ImageUrl { get; set; } 

        public string Category { get; set; } 

        public decimal PriceToWin { get; set; } 

        public string ImageId { get; set; }

        public byte[] ImageArray { get; set; }

    }
}
