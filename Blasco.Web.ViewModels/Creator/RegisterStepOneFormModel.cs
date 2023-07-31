using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Web.ViewModels.Creator
{
    public class RegisterStepOneFormModel
    {
        [Required]
        public string Role { get; set; } = null!;
    }
}
