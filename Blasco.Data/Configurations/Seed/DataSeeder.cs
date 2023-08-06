using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Blasco.Data.Models;
using static Blasco.Common.DataSeederConstatnts;
using static Blasco.Common.GeneralApplicationConstants;
using Microsoft.EntityFrameworkCore;

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
                Pseudonym = "firstPseudonym"
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
                Pseudonym = "secondPseudonym"
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

        //AllRoles
        private static IReadOnlyCollection<IdentityRole<Guid>> allRoles = new List<IdentityRole<Guid>>()
        {
            new IdentityRole<Guid>
            {
                Id = Guid.Parse(AdminRoleId),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },

            new IdentityRole<Guid>
            {
                Id = Guid.Parse(CreatorRoleId),
                Name = "Creator",
                NormalizedName = "CREATOR"
            },

            new IdentityRole<Guid>
            {
                Id = Guid.Parse(CustomerRoleId),
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            },
        }.AsReadOnly();

        private static IReadOnlyCollection<IdentityUserRole<Guid>> asignRoles = new List<IdentityUserRole<Guid>>
        {
            //Asign Admin
            new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse(AdminRoleId),
                UserId = Guid.Parse(AdminId),
            },

            //Asign Creator
            new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse(CreatorRoleId),
                UserId = Guid.Parse(FirstCreatorId),
            },

            new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse(CreatorRoleId),
                UserId = Guid.Parse(SecondCreatorId),
            },

            //Asign Customer
            new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse(CustomerRoleId),
                UserId = Guid.Parse(FirstCustomerId),
            },

            new IdentityUserRole<Guid>()
            {
                RoleId = Guid.Parse(CustomerRoleId),
                UserId = Guid.Parse(SecondCustomerId),
            },
        }.AsReadOnly();


        //Challenges
        private static IReadOnlyCollection<Challenge> challenges = new List<Challenge>()
        {
            new Challenge
            {
                Id = Guid.Parse(GraphicDesignChallengeId),
                Title = "Architectural Visions: Redesign Our Identity",
                Description = "Are you a creative mind with a flair for design? Put your artistic prowess to the test and join our exciting contest, \"Architectural Visions: Redesign Our Identity.\"\r\n\r\nAre you up for the challenge? Unleash your creativity and design a new logo that symbolizes the essence of Architecture, evoking elegance, forward-thinking concepts, and a seamless fusion of form and function.",
                CategoryId = 5,
                PriceToWin = 200,
                IsOnGoing = true,
                IsActive = true,
                CustomerCreatedChallengeId = Guid.Parse(SecondCustomerId)
            },
            new Challenge
            {
                Id = Guid.Parse(PhotographChallengeId),
                Title = "Capturing Nature's Wonders: A Photographic Odyssey",
                Description = "Calling all nature enthusiasts and photography enthusiasts alike! Embark on a visual journey of awe and wonder as we invite you to participate in our thrilling contest, \"Capturing Nature's Wonders: A Photographic Odyssey.\" Immerse yourself in the beauty of the natural world and showcase your talent by capturing the most mesmerizing moments in nature through your lens.",
                CategoryId = 10,
                PriceToWin = 200,
                IsOnGoing = true,
                IsActive = true,
                CustomerCreatedChallengeId = Guid.Parse(SecondCustomerId)
            }
        };

        //Projects
        private static IReadOnlyCollection<Project> projects = new List<Project>()
        {
            new Project
            {
                Id = Guid.Parse(GiraffeProjectId),
                Title = "Giraffe",
                Description = "In Collaboration with the Zoo: Graceful Giants Unveiled - A Mesmerizing Giraffe Photoshoot\r\nStep into a world of wonder as our lens captures the mesmerizing charm of giraffes, revealing their elegant grace and captivating allure. Witness these gentle giants in their natural habitat, towering above the savanna, their majestic presence leaving an indelible mark on your heart. ",
                CategoryId = 10,
                IsActive = true,
                CreatorId = Guid.Parse(FirstCreatorId),
                ChallengeId = Guid.Parse(PhotographChallengeId),
            },
            new Project
            {
                Id = Guid.Parse(FieldProjectId),
                Title = "Fields",
                Description = "This endeavor seeks to encapsulate the enchanting allure of open landscapes, translating the serene expanse and delicate details of fields into a breathtaking visual experience. Immerse yourself in the essence of nature's tranquility and embrace the artistry that brings the field's beauty to life in a captivating display of creativity and awe-inspiring imagery.",
                CategoryId = 10,
                IsActive = true,
                CreatorId = Guid.Parse(SecondCreatorId),
                ChallengeId = Guid.Parse(PhotographChallengeId),
            },

            new Project
            {
                Id = Guid.Parse(GraphicDesignProjectId),
                Title = "Architecture Brand Identity",
                Description = "In my design I reimagined the identity by drawing inspiration from the mesmerizing patterns and structural elements of iconic architectural landmarks worldwide. Through a harmonious blend of modern aesthetics and timeless elegance, I created a visually captivating representation that symbolizes our collective journey towards a progressive and interconnected future.",
                CategoryId = 5,
                IsActive = true,
                CreatorId = Guid.Parse(SecondCreatorId),
                ChallengeId = Guid.Parse(GraphicDesignChallengeId)
            },

            new Project
            {
                Id = Guid.Parse(TapestryProjectId),
                Title = "Oriental Tapestry",
                Description = "Embark on a captivating journey through culture and history with my Oriental Tapestry Project. This creative endeavor weaves together intricate threads of Eastern traditions, vibrant colors, and timeless narratives, crafting a mesmerizing masterpiece that transports viewers to distant lands. Immerse yourself in the rich tapestry of Asia's heritage, where artistry and storytelling intertwine in a captivating display of beauty and meaning.",
                CategoryId = 13,
                IsActive = true,
                CreatorId = Guid.Parse(FirstCreatorId)
            }

        };

        //Products
        private static IReadOnlyCollection<Product> products = new List<Product>()
        {
            new Product
            {
                Id = Guid.Parse(BeesProductId),
                Title = "Bees",
                Description = "A group of bees compete for the only female in the group. Climate change, pesticides and ever-dwindling habitat make it difficult for bees around the world to maintain their species.",
                Price = 35,
                CategoryId = 10,
                CreatorId = Guid.Parse(FirstCreatorId),
                IsActive = true,
                City = "Buenos Aires",
                CustomerId = Guid.Parse(FirstCustomerId)
            },

            new Product
            {
                Id = Guid.Parse(VaseProductId),
                Title = "Ornate vase with intricate floral pattern design",
                Description = "Taking her art from life and nature, she breaks down forms simplifying and playing with the uses of light and shadows. Sometimes staying true to a likeness, which is always the starting point, but sometimes her work will take on a much more abstract nature.",
                Price = 170,
                CategoryId = 8,
                CreatorId = Guid.Parse(SecondCreatorId),
                IsActive = true,
                City = "London",
                CustomerId = Guid.Parse(FirstCustomerId)
            },

            new Product
            {
                Id = Guid.Parse(SpacemanProductId),
                Title = "Spaceman",
                Description = "High-quality Print of a Spaceman dancing music poster flyer design element",
                Price = 25,
                CategoryId = 11,
                IsActive = true,
                CreatorId = Guid.Parse(SecondCreatorId),
                City = "Madrid"
            },


            new Product
            {
                Id = Guid.Parse(PaintingProductId),
                Title = "Heavy Textured 3d Abstract Art Painting",
                Description = "Discover the beauty of flowers with this stunning Found a Flower Bouquet in Heavy Textured 3d Abstract Art. The intricate botanical design is both abstract and realistic, capturing the essence of nature in a unique and eye-catching way. Measuring 12x18 inches, it's the perfect size to make a stateme...",
                Price = 120,
                CategoryId = 9,
                IsActive = true,
                CreatorId = Guid.Parse(FirstCreatorId)
            }
        };

        //AppUserPPCategory
        private static IReadOnlyCollection<ApplicationUserPPCategory> applicationUserPPCategory = new List<ApplicationUserPPCategory>()
        {
            new ApplicationUserPPCategory
            {
                ApplicationUserId = Guid.Parse(FirstCreatorId),
                PPCategoryId = 10
            },
            new ApplicationUserPPCategory
            {
                ApplicationUserId = Guid.Parse(FirstCreatorId),
                PPCategoryId = 13
            },
            new ApplicationUserPPCategory
            {
                ApplicationUserId = Guid.Parse(FirstCreatorId),
                PPCategoryId = 9
            },
            new ApplicationUserPPCategory
            {
                ApplicationUserId = Guid.Parse(SecondCreatorId),
                PPCategoryId = 5
            },
            new ApplicationUserPPCategory
            {
                ApplicationUserId = Guid.Parse(SecondCreatorId),
                PPCategoryId = 8
            },
            new ApplicationUserPPCategory
            {
                ApplicationUserId = Guid.Parse(SecondCreatorId),
                PPCategoryId = 11
            },
        };

        //Votes
        private static IReadOnlyCollection<Vote> votes = new List<Vote>()
        {
            new Vote
            {
                Id = Guid.Parse("953a5321-ee41-4397-9736-3972caa5aca4"),
                ProjectCastOnId = Guid.Parse(GraphicDesignProjectId),
                ApplicationUserWhoVotedId = Guid.Parse(FirstCreatorId),
                ChallengeId= Guid.Parse(GraphicDesignChallengeId)
            },
            new Vote
            {
                Id = Guid.Parse("5d6529bb-d319-45b6-b454-3d2c68da4633"),
                ProjectCastOnId = Guid.Parse(GiraffeProjectId),
                ApplicationUserWhoVotedId = Guid.Parse(SecondCreatorId),
                ChallengeId= Guid.Parse(PhotographChallengeId)
            },
        };


        internal static void SeedPPCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductProjectCategory>()
                .HasData(productProjectCategories);
        }
        internal static void SeedCustomerTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerType>()
                .HasData(customerType);
        }
        internal static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasData(admin);
            modelBuilder.Entity<ApplicationUser>()
                .HasData(creators);
            modelBuilder.Entity<ApplicationUser>()
                .HasData(customers);
        }
        internal static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<Guid>>()
                .HasData(allRoles);
        }
        internal static void AsignRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasData(asignRoles);
        }
        internal static void SeedChallenges(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>()
                .HasData(challenges);
        }
        internal static void SeedProjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasData(projects);
        }
        internal static void SeedProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(products);
        }
        internal static void SeedApplicationUserPPCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserPPCategory>()
                .HasData(applicationUserPPCategory);
        }
        internal static void SeedVotes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vote>()
                .HasData(votes);
        }

        private static string HashPassword(string password)
        {
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            return passwordHasher.HashPassword(null!, password);
        }
    }
}
