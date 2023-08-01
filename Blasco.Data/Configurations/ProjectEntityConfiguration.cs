namespace Blasco.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Blasco.Data.Models;

    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(p => p.IsActive)
                .HasDefaultValue(true);


            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Creator)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Challenge)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ChallengeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateProjects());
        }

        private Project[] GenerateProjects()
        {
            ICollection<Project> projects = new HashSet<Project>();

            Project project;

            project = new Project()
            {
                Title = "Fallingwater",
                Description = "Fallingwater is a house designed by the architect Frank Lloyd Wright in 1935 in the Laurel Highlands of southwest Pennsylvania, about 70 miles (110 km) southeast of Pittsburgh in the United States. It is built partly over a waterfall on Bear Run in the Mill Run section of Stewart Township, Fayette County, Pennsylvania.",
                ImageUrl = "https://en.wikipedia.org/wiki/Fallingwater#/media/File:Fallingwater3.jpg",
                CategoryId = 2,
                CreatorId = Guid.Parse("635E95CA-66D3-424B-A63B-6C17B36BBB42")
            };
            projects.Add(project);

            project = new Project()
            {
                Title = "The Year Zero",
                Description = "Sarpaneva made his and Finland's largest glass sculpture, Ahtojää (\"Pack Ice,\" renamed from Jäävuori, \"Iceberg\"), for the Finnish pavilion at Expo 67 in Montreal in 1967.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/34/The_Year_Zero_1985_Sarpaneva.jpg",
                CategoryId = 4,
                CreatorId = Guid.Parse("635E95CA-66D3-424B-A63B-6C17B36BBB42")
            };
            projects.Add(project);

            project = new Project()
            {
                Title = "Giraffe",
                Description = "In Collaboration with the Zoo: Graceful Giants Unveiled - A Mesmerizing Giraffe Photoshoot\r\nStep into a world of wonder as our lens captures the mesmerizing charm of giraffes, revealing their elegant grace and captivating allure. Witness these gentle giants in their natural habitat, towering above the savanna, their majestic presence leaving an indelible mark on your heart. ",
                ImageUrl = "https://static.photocrowd.com/upl/YJ/cms.z47KexT7uDpD2YJWlvXw-collection_cover.jpeg",
                CategoryId = 10,
                CreatorId = Guid.Parse("635E95CA-66D3-424B-A63B-6C17B36BBB42"),
                ChallengeId = Guid.Parse("F9DDE318-3A7E-4227-8097-44F816827DA6")
            };
            projects.Add(project);

            project = new Project()
            {
                Title = "Architecture Brand Identity",
                Description = "In my design I reimagined the identity by drawing inspiration from the mesmerizing patterns and structural elements of iconic architectural landmarks worldwide. Through a harmonious blend of modern aesthetics and timeless elegance, I created a visually captivating representation that symbolizes our collective journey towards a progressive and interconnected future. By infusing vibrant hues and intricate details, my design communicates a compelling narrative of transformation, embracing both our rich architectural heritage and innovative spirit.",
                ImageUrl = "https://weandthecolor.com/wp-content/uploads/2013/03/Architecture-Brand-Identity-University-Project-by-Matt-Purcell.jpg",
                CategoryId = 5,
                CreatorId = Guid.Parse("635E95CA-66D3-424B-A63B-6C17B36BBB42"),
                ChallengeId = Guid.Parse("A1D2AFCA-1D02-4823-AE42-93C9F3C50D44")
            };
            projects.Add(project);

            return projects.ToArray();

        }

    }
}
