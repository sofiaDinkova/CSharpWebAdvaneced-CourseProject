namespace Blasco.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;
    using System.Reflection;

    public class BlascoDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public BlascoDbContext(DbContextOptions<BlascoDbContext> options)
            : base(options)
        {

        }

        public DbSet<ProductProjectCategory> ProductProjectCategories { get; set; } = null!;

        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<CustomerType> CustomerTypes { get; set; } = null!;

        public DbSet<Vote> Votes { get; set; } = null!;

        public DbSet<Challenge> Challenges { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(BlascoDbContext)) ??
                                                        Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
           
        }
    }
}