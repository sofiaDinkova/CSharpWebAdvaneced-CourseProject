using Blasco.Data;
using Blasco.Data.Models;
using Blasco.Services.Data.Interfaces;
using Blasco.Services.Data.Models.Product;
using Blasco.Web.ViewModels.Challenge;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using static Blasco.Data.BlascoMongoExperimental;

namespace Blasco.Services.Data
{
    public class ChallengeService : IChallengeService
    {
        private readonly BlascoDbContext dbContext;
        private MongoClient dbClient;
        
        public ChallengeService(BlascoDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbClient = new MongoClient("mongodb://localhost:27017");
        }
        public async Task<AllChallengesModel> AllChallengesAsync()
        {
            IMongoDatabase db = dbClient.GetDatabase("testdb");

            var imageCollection = db.GetCollection<Image>("photo");
            var queryableCollection = imageCollection.AsQueryable();

            IEnumerable<ChallangeAllViewModel> allChallengeModels = await this.dbContext
                .Challenges
                .Select(c => new ChallangeAllViewModel
                {
                    Id = c.Id.ToString(),
                    Title = c.Title,
                    Description = c.Description,
                    //ImageUrl = c.ImageUrl,
                    Category = c.Category.Name,
                    PriceToWin = c.PriceToWin,
                })
                .ToArrayAsync();
            foreach (var challange in allChallengeModels)
            {
                //var query = queryableCollection
                //           .Where(r => r.EntityCorrespondingId == challange.Id.ToString())
                //           .Select(r => new { r.ContentImage });


                //var d = BsonSerializer.Deserialize < byte[]>(query.ToJson());
                byte[] biteImg = GetImageBytes(challange.Id);
                challange.ImageArray = biteImg;



            }

            
            return new AllChallengesModel()
            {
                TotalChallengesCount = allChallengeModels.Count(),
                Challenges = allChallengeModels
            };
        }

        public byte[] GetImageBytes(string imageId)
        {
            IMongoDatabase db = dbClient.GetDatabase("testdb");

            var imageCollection = db.GetCollection<Image>("photo");

            // Retrieve the image data from MongoDB
            var filter = Builders<Image>.Filter.Eq("EntityCorrespondingId", imageId);
            var imageDocument = imageCollection.Find(filter).FirstOrDefault();

            if (imageDocument != null)
            {
                // Extract binary data from the Image entity
                byte[] imageBytes = imageDocument.ContentImage;

                return imageBytes;
            }

            return null; // Image not found
        }















        public async Task<int> ReturnCategoryIdByChallengeIdAsync(string challengeId)
        {
            Challenge challenge = await this.dbContext
                .Challenges
                .FirstAsync(c => c.Id.ToString() == challengeId);

            return challenge.CategoryId;
        }
    }
}
