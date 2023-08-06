
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

        public async void SeedImage()
        {
            var pack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("elementNameConvention", pack, x => true);

            var coll = GetCollection<Image>("blasco", "image");

            //ChallengesImagesSeed
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
                await coll.InsertOneAsync(image);
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
                await coll.InsertOneAsync(image);
            }

            //ProductImagesSeed
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
                await coll.InsertOneAsync(image);
            }


            filter = Builders<Image>.Filter.Eq("FileName", "Bees");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Bees.PNG");
                byte[] binaryContentSecond = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Bees1.PNG");

                Image[] images = new[]
                {
                    new Image()
                    {
                    FileName = "Bees",
                    EntityCorrespondingId = "7cee0b9a-2b1a-49e1-bfa6-f3f3e63626de",
                    ContentImage = binaryContent
                    },
                    new Image()
                    {
                    FileName = "Bees",
                    EntityCorrespondingId = "7cee0b9a-2b1a-49e1-bfa6-f3f3e63626de",
                    ContentImage = binaryContentSecond
                    }
                };
                await coll.InsertManyAsync(images);
            }


            filter = Builders<Image>.Filter.Eq("FileName", "Ornate vase with intricate floral pattern design");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\OrnateVase.PNG");
                byte[] binaryContentSecond = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\OrnateVase1.PNG");

                Image[] images = new[]
                {
                    new Image()
                    {
                    FileName = "Ornate vase with intricate floral pattern design",
                    EntityCorrespondingId = "2700b45e-314b-4e66-b607-5f3cb9927852",
                    ContentImage = binaryContent
                    },
                    new Image()
                    {
                    FileName = "Ornate vase with intricate floral pattern design",
                    EntityCorrespondingId = "2700b45e-314b-4e66-b607-5f3cb9927852",
                    ContentImage = binaryContentSecond
                    }
                };
                await coll.InsertManyAsync(images);
            }


            filter = Builders<Image>.Filter.Eq("FileName", "Spaceman");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Spaceman.PNG");

                Image image = new()
                {
                    FileName = "Spaceman",
                    EntityCorrespondingId = "e667cc6a-341f-4320-9fdc-3fdc60cc7fff",
                    ContentImage = binaryContent
                };
                await coll.InsertOneAsync(image);
            }


            filter = Builders<Image>.Filter.Eq("FileName", "Heavy Textured 3d Abstract Art Painting");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Painting.PNG");
                byte[] binaryContentSecond = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Painting1.PNG");

                Image[] images = new[]
                {
                    new Image()
                    {
                    FileName = "Heavy Textured 3d Abstract Art Painting",
                    EntityCorrespondingId = "8eab24f6-7888-4aa6-9ecd-5eae3d3c110e",
                    ContentImage = binaryContent
                    },
                    new Image()
                    {
                    FileName = "Heavy Textured 3d Abstract Art Painting",
                    EntityCorrespondingId = "8eab24f6-7888-4aa6-9ecd-5eae3d3c110e",
                    ContentImage = binaryContentSecond
                    }
                };
                await coll.InsertManyAsync(images);
            }


            //ProjectsImagesSeed
            filter = Builders<Image>.Filter.Eq("FileName", "Giraffe");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Giraffe.jpg");
                byte[] binaryContentSecond = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Giraffe1.jpg");

                Image[] images = new[]
                {
                    new Image()
                    {
                    FileName = "Giraffe",
                    EntityCorrespondingId = "65786e09-08fc-4bb3-bf02-665ff651c8e5",
                    ContentImage = binaryContent
                    },
                    new Image()
                    {
                    FileName = "Giraffe",
                    EntityCorrespondingId = "65786e09-08fc-4bb3-bf02-665ff651c8e5",
                    ContentImage = binaryContentSecond
                    }
                };
                await coll.InsertManyAsync(images);
            }


            filter = Builders<Image>.Filter.Eq("FileName", "Fields");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Fields.PNG");
                byte[] binaryContentSecond = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\Fields1.PNG");

                Image[] images = new[]
                {
                    new Image()
                    {
                    FileName = "Fields",
                    EntityCorrespondingId = "b10ce869-5388-47c4-88b8-0ebe7da7d7e3",
                    ContentImage = binaryContent
                    },
                    new Image()
                    {
                    FileName = "Fields",
                    EntityCorrespondingId = "b10ce869-5388-47c4-88b8-0ebe7da7d7e3",
                    ContentImage = binaryContentSecond
                    }
                };
                await coll.InsertManyAsync(images);
            }


            filter = Builders<Image>.Filter.Eq("FileName", "Architecture Brand Identity");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\ArchitectureBrand.jpg");

                Image image = new()
                {
                    FileName = "Architecture Brand Identity",
                    EntityCorrespondingId = "5d3533b4-c059-47eb-9333-ae8cc728015d",
                    ContentImage = binaryContent
                };
                await coll.InsertOneAsync(image);
            }


            filter = Builders<Image>.Filter.Eq("FileName", "Oriental Tapestry");
            imageDocument = coll.Find(filter).FirstOrDefault();

            if (imageDocument == null)
            {
                byte[] binaryContent = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\OrientalTapestry.PNG");
                byte[] binaryContentSecond = File.ReadAllBytes("..\\Blasco.Web\\wwwroot\\ImagesToLoad\\OrientalTapestry1.PNG");

                Image[] images = new[]
                {
                    new Image()
                    {
                    FileName = "Oriental Tapestry",
                    EntityCorrespondingId = "adeacb8d-6173-46ee-9b7b-c5696d55111a",
                    ContentImage = binaryContent
                    },
                    new Image()
                    {
                    FileName = "FieOriental Tapestrylds",
                    EntityCorrespondingId = "adeacb8d-6173-46ee-9b7b-c5696d55111a",
                    ContentImage = binaryContentSecond
                    }
                };
                await coll.InsertManyAsync(images);
            }
        }
    }
}
