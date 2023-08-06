using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Data.Models
{
    public class ApplicationUserPPCategory
    {
        //Mapping table for Many-to-Many Relationship between ApplicationUser & ProductProjectCategory
        public int PPCategoryId { get; set; }

        public ProductProjectCategory ProductProjectCategory { get; set; } 

        public Guid ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
