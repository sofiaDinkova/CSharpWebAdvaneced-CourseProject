namespace Blasco.Data.Models
{
    using System;

    public class ApplicationUserPPCategory
    {
        //Mapping table for Many-to-Many Relationship between ApplicationUser & ProductProjectCategory
        public int PPCategoryId { get; set; }

        public ProductProjectCategory ProductProjectCategory { get; set; } = null!;

        public Guid ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
