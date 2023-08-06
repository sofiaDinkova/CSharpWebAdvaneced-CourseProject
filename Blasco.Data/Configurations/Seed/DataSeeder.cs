using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Blasco.Data.Models;
using static Blasco.Common.DataSeederConstatnts.Users;

namespace Blasco.Data.Configurations.Seed
{
    internal static class DataSeeder
    {
        //ProductProjectCategory
        private static IReadOnlyCollection<ProductProjectCategory> productProjectCategories = new List<ProductProjectCategory>()
        {
            new ProductProjectCategory
            {
                Id = 1,
                Name = "Animation"
            },
            new ProductProjectCategory
            {
                Id = 2,
                Name = "Architectural plan"
            },
            new ProductProjectCategory
            {
                Id = 3,
                Name = "Furniture"
            },
            new ProductProjectCategory
            {
                Id = 4,
                Name = "Glass sculpture"
            },
            new ProductProjectCategory
            {
                Id = 5,
                Name = "Graphic design"
            },
            new ProductProjectCategory
            {
                Id = 6,
                Name = "Illustration"
            },
            new ProductProjectCategory
            {
                Id = 7,
                Name = "Interior design"
            },
            new ProductProjectCategory
            {
                Id = 8,
                Name = "Metal designs"
            },
            new ProductProjectCategory
            {
                Id = 9,
                Name = "Painting"
            },
            new ProductProjectCategory
            {
                Id = 10,
                Name = "Photograph"
            },
            new ProductProjectCategory
            {
                Id = 11,
                Name = "Print"
            },
            new ProductProjectCategory
            {
                Id = 12,
                Name = "Sculpture"
            },
            new ProductProjectCategory
            {
                Id = 13,
                Name = "Tapestry"
            },
            new ProductProjectCategory
            {
                Id = 14,
                Name = "Video"
            },

        };

        //CustomerType
        private static IReadOnlyCollection<CustomerType> customerType = new List<CustomerType>()
        {
            new CustomerType
            {
                Id = 1,
                Name = "Private Customer"
            },
            new CustomerType
            {
                Id = 2,
                Name = "Freelancer"
            },
            new CustomerType
            {
                Id = 3,
                Name = "Buisness"
            },
        };

        //Users
        private static ApplicationUser admin = new ApplicationUser()
        {

            Id = Guid.Parse(AdminId),
            FirstName = "Admin",
            LastName = "Admin",
            UserName = "Admin",
            NormalizedUserName = "ADMIN",
            Email = AdminEmail,
            NormalizedEmail = "ADMIN@BLASCO.COM",
            EmailConfirmed = false,
            PasswordHash = HashPassword(AdminPassword),
            LockoutEnabled = true,
            LockoutEnd = null,
            AccessFailedCount = 0,
            TwoFactorEnabled = false,
            IsActive = true,
        };

        private static IReadOnlyCollection<ApplicationUser> creators = new List<ApplicationUser>()
        {
            new ApplicationUser
            {
                Id = Guid.Parse(FirstCreatorId),
                FirstName = "First",
                LastName = "Creator",
                UserName = "FirstCreator",
                NormalizedUserName = "FIRSTCREATOR",
                Email = FirstCreatorEmail,
                NormalizedEmail = "FIRSTCREATOR@CREATOR.COM",
                EmailConfirmed = false,
                PasswordHash = HashPassword(FirstCreatorPassword),
                LockoutEnabled = true,
                LockoutEnd = null,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                IsActive = true,
                Pseudonym = "firstCreativePseudonym"
            },

            new ApplicationUser
            {
                Id = Guid.Parse(SecondCreatorId),
                FirstName = "Second",
                LastName = "Creator",
                UserName = "SecondCreator",
                NormalizedUserName = "SECONDCREATOR",
                Email = SecondCreatorEmail,
                NormalizedEmail = "SECONDCREATOR@CREATOR.COM",
                EmailConfirmed = false,
                PasswordHash = HashPassword(SecondCreatorId),
                LockoutEnabled = true,
                LockoutEnd = null,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                IsActive = true,
                Pseudonym = "secondCreativePseudonym"
            },
        };

        private static IReadOnlyCollection<ApplicationUser> customers = new List<ApplicationUser>()
        {
            new ApplicationUser
            {
                Id = Guid.Parse(FirstCustomerId),
                FirstName = "First",
                LastName = "Customer",
                UserName = "FirstCustomer",
                NormalizedUserName = "FIRSTCUSTOMER",
                Email = FirstCustomerEmail,
                NormalizedEmail = "FIRSTCUSTOMER@CUSTOMER.COM",
                EmailConfirmed = false,
                PasswordHash = HashPassword(FirstCustomerPassword),
                LockoutEnabled = true,
                LockoutEnd = null,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                IsActive = true,
                CustomerTypeId = 2,
            },

            new ApplicationUser
            {
                Id = Guid.Parse(SecondCustomerId),
                FirstName = "Second",
                LastName = "Customer",
                UserName = "SecondCustomer",
                NormalizedUserName = "SECONDCUSTOMER",
                Email = SecondCustomerEmail,
                NormalizedEmail = "SECONDCUSTOMER@CUSTOMER.COM",
                EmailConfirmed = false,
                PasswordHash = HashPassword(SecondCustomerPassword),
                LockoutEnabled = true,
                LockoutEnd = null,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                IsActive = true,
                CustomerTypeId = 1,
            },
        };
        //Challenges
        private static IReadOnlyCollection<Challenge> challenges = new List<Challenge>()
        {
            new Challenge
            {
                Title = "Architectural Visions: Redesign Our Identity",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQt_6cdJdGcppF55kqefSCDtaPuH9CFyZx1ktsjy1AX5GhsO4hGDYnZXtExPtahHlQkpdg&usqp=CAU",
                Description = "Are you a creative mind with a flair for design? Put your artistic prowess to the test and join our exciting contest, \"Architectural Visions: Redesign Our Identity.\"\r\n\r\nAre you up for the challenge? Unleash your creativity and design a new logo that symbolizes the essence of Architecture, evoking elegance, forward-thinking concepts, and a seamless fusion of form and function.",
                CategoryId = 5,
                PriceToWin = 200,
                IsOnGoing = true
            }
        };


        private static string HashPassword(string password)
        {
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            return passwordHasher.HashPassword(null!, password);
        }
    }
}
