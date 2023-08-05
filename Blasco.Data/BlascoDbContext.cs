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
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Configure ApplicationUser
            builder.Entity<ApplicationUser>()
                .HasOne(p => p.CustomerType)
                .WithMany(c => c.Customers)
                .HasForeignKey(p => p.CustomerTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Creators);


            //Configure Product
            builder.Entity<Product>()
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Product>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasOne(p => p.Creator)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);


            //Configure Challenge
            builder.Entity<Challenge>()
               .Property(p => p.CreatedOn)
               .HasDefaultValueSql("GETDATE()");

            builder.Entity<Challenge>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Challenges)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            //Configure Project
            builder.Entity<Project>()
                .Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.Entity<Project>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.Entity<Project>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
                .HasOne(p => p.Creator)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Project>()
                .HasOne(p => p.Challenge)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ChallengeId)
                .OnDelete(DeleteBehavior.Restrict);


            //Configure Vote
            builder.Entity<Vote>()
               .Property(p => p.CreatedOn)
               .HasDefaultValueSql("GETDATE()");

            builder.Entity<Vote>()
                .HasOne(v => v.ApplicationUserWhoVoted)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.ApplicationUserWhoVotedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Vote>()
                .HasOne(v => v.ProjectCastOn)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.ProjectCastOnId)
                .OnDelete(DeleteBehavior.Restrict);


            //Assembly configAssembly = Assembly.GetAssembly(typeof(BlascoDbContext)) ??
            //                                            Assembly.GetExecutingAssembly();

            //builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);

        }
        public DbSet<ProductProjectCategory> ProductProjectCategories { get; set; } = null!;

        public DbSet<Project> Projects { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<CustomerType> CustomerTypes { get; set; } = null!;

        public DbSet<Vote> Votes { get; set; } = null!;

        public DbSet<Challenge> Challenges { get; set; } = null!;

    }
}