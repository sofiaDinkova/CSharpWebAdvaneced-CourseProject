using Blasco.Data;
using Blasco.Data.Models;
using Blasco.Services.Data;
using Microsoft.EntityFrameworkCore;
using Blasco.Services.Tests.DataBase;
using Blasco.Services.Data.Interfaces;

namespace Blasco.Services.Tests
{
    [TestFixture]
    public class CustomerServiceTest
    {
        private CustomerService customerService;
        private BlascoDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            this.dbContext = InMemoryDatabase.Instance();
            this.customerService = new CustomerService(this.dbContext);
            await SeedData();
        }

        [Test]
        public async Task HasProductWithIdAsync_ProductExists_ReturnsTrue()
        {
            // Arrange
            string productId = "validProductId";
            string userId = "validUserId";

            var product = new Product { Id = new Guid(productId), CustomerId = new Guid(userId) };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            // Act
            bool result = await customerService.HasProductWithIdAsync(productId, userId);

            // Assert
            Assert.IsTrue(result);
        }

        private async Task SeedData()
        {
            // Create test user.
            string userId = Guid.NewGuid().ToString();

            ApplicationUser user = new ApplicationUser
            {
                Id = Guid.Parse("a6c34879-8566-4d62-94fa-b4544bd8a8d2"),
                FirstName = "Test",
                LastName = "Testov",
                UserName = "testov@test.com",
                NormalizedUserName = "TESTOV@TEST.COM",
                Email = "testov@test.com",
                NormalizedEmail = "TESTOV@TEST.COM",                
            };

            // Add user to database.
            await this.dbContext.Users.AddAsync(user);

            // Save changes.
            await this.dbContext.SaveChangesAsync();
        }
    }
}