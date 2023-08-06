
using Blasco.Data.Models;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Blasco.Data.BlascoMongoDbFactory
{
    public class MongoDbFactory :IMongoDbFactory
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


            byte[] binaryContent = File.ReadAllBytes("image.jpg");

            var photos = new[]
            {
                new Image
                {
                    FileName = "Test",
                    EntityCorrespondingId = "2871D55E-AE05-40CC-BBC3-E5EB8803EB70",
                    ContentImage = binaryContent
                }
            };

            coll.InsertMany(photos);



        }
    }
}
