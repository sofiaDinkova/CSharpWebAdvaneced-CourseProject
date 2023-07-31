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

            return projects.ToArray();

        }

    }
}
