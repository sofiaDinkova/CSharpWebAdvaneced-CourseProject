
using Blasco.Data.BlascoMongoDbFactory.Interfaces;
using Blasco.Data.Models;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Blasco.Data.BlascoMongoDbFactory
{
    public class MongoDbFactory : IMongoDbFactory
    {
        private readonly MongoClient _client;

        public MongoDbFactory()
        {
            //var settings = MongoClientSettings.FromConnectionString(connectionString);
            //settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            _client = new MongoClient("mongodb://localhost:27017");
        }


        public IMongoCollection<T> GetCollection<T>(string databaseName, string collectionNme)
        {
            return _client.GetDatabase(databaseName).GetCollection<T>(collectionNme);
        }

        public void SeedImage()
        {
            var pack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("elementNameConvention", pack, x => true);

            var coll = GetCollection<Image>("blasco", "image");

            //SeedChallengesImages
            var filter = Builders<Image>.Filter.Eq("FileName", "Capturing Nature's Wonders: A Photographic Odyssey");
            Image imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\PhotographNatureChallenge.PNG");

                Image image = new()
                {
                    FileName = "Capturing Nature's Wonders: A Photographic Odyssey",
                    EntityCorrespondingId = "a84295eb-82fd-4aac-9330-505b88e228ff",
                    ContentImage = binaryContent
                };

                coll.InsertOne(image);
            }

            filter = Builders<Image>.Filter.Eq("FileName", "Architectural Visions: Redesign Our Identity");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\GraphicDesignChallenge.jpg");

                Image image = new()
                {
                    FileName = "Architectural Visions: Redesign Our Identity",
                    EntityCorrespondingId = "bd64aee7-19e4-4fc6-8db7-7388e3cc8191",
                    ContentImage = binaryContent
                };

                coll.InsertOne(image);
            }




        }
    }
}
