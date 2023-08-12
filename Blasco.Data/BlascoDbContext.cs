namespace Blasco.Data
{
    using System.Reflection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;
    using Configurations.Seed;

    public class BlascoDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public BlascoDbContext(DbContextOptions<BlascoDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(BlascoDbContext)) ??
                                                        Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);
            base.OnModelCreating(builder);

            DataSeeder.SeedPPCategory(builder);
            DataSeeder.SeedCustomerTypes(builder);
            DataSeeder.SeedUsers(builder);
            DataSeeder.SeedRoles(builder);
            DataSeeder.AsignRoles(builder);
            DataSeeder.SeedChallenges(builder);
            DataSeeder.SeedProjects(builder);
            DataSeeder.SeedProducts(builder);
            DataSeeder.SeedApplicationUserPPCategory(builder);
            DataSeeder.SeedVotes(builder);
        }

        public DbSet<ProductProjectCategory> ProductProjectCategories { get; set; } = null!;

        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<CustomerType> CustomerTypes { get; set; } = null!;

        public DbSet<Vote> Votes { get; set; } = null!;

        public DbSet<Challenge> Challenges { get; set; } = null!;

        public DbSet<ApplicationUserPPCategory> ApplicationUserPPCategories { get; set;} = null!;

        public DbSet<Message> Messages { get; set;} = null!;
    }
}